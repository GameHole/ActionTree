Shader "MYUI/CUT"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)

        _StencilComp ("Stencil Comparison", Float) = 8
        _Stencil ("Stencil ID", Float) = 0
        _StencilOp ("Stencil Operation", Float) = 0
        _StencilWriteMask ("Stencil Write Mask", Float) = 255
        _StencilReadMask ("Stencil Read Mask", Float) = 255

        _ColorMask ("Color Mask", Float) = 15
        [Toggle(UNITY_UI_ALPHACLIP)] _UseUIAlphaClip ("Use Alpha Clip", Float) = 0
    }

    SubShader
    {
        Tags
        {
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }

        Stencil
        {
            Ref [_Stencil]
            Comp [_StencilComp]
            Pass [_StencilOp]
            ReadMask [_StencilReadMask]
            WriteMask [_StencilWriteMask]
        }

        Cull Off
        Lighting Off
        ZWrite Off
        ZTest [unity_GUIZTestMode]
        Blend SrcAlpha OneMinusSrcAlpha
        ColorMask [_ColorMask]

        Pass
        {
            Name "Default"
        CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 2.0

            #include "UnityCG.cginc"
            #include "UnityUI.cginc"

            //#pragma multi_compile_local _ UNITY_UI_CLIP_RECT
            //#pragma multi_compile_local _ UNITY_UI_ALPHACLIP

            struct appdata_t
            {
                float4 vertex   : POSITION;
                float4 color    : COLOR;
                float2 texcoord : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct v2f
            {
                float4 vertex   : SV_POSITION;
                fixed4 color    : COLOR;
                float2 texcoord  : TEXCOORD0;
                float4 worldPosition : TEXCOORD1;
				float4 localPosition : TEXCOORD2;
                UNITY_VERTEX_OUTPUT_STEREO
            };

			float4x4 _world2local;
			float4x4 _localworld;

			float _w;
			float _h;
            sampler2D _MainTex;
            fixed4 _Color;
            fixed4 _TextureSampleAdd;
            float4 _ClipRect;
            float4 _MainTex_ST;
			float4 _OrgionAndSize;
			fixed4 _BGColor;
            v2f vert(appdata_t v)
            {
                v2f OUT;
				OUT.localPosition = mul( _world2local,mul(_localworld, v.vertex));
				OUT.localPosition.x /= _w;
				OUT.localPosition.y /= _h;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(OUT);
                OUT.worldPosition = v.vertex;
                OUT.vertex = UnityObjectToClipPos(OUT.worldPosition);
				float2 duv = v.texcoord - _OrgionAndSize.xy;
                OUT.texcoord = v.texcoord + _MainTex_ST.zw;
                OUT.color = v.color * _Color;
                return OUT;
            }
			float cutconner(float2 localPosition);
			fixed4 limitcolor(fixed4 color,float2 uv);
            fixed4 frag(v2f IN) : SV_Target
            {
                half4 color = (tex2D(_MainTex, IN.texcoord) + _TextureSampleAdd) * IN.color;

                #ifdef UNITY_UI_CLIP_RECT
                color.a *= UnityGet2DClipping(IN.worldPosition.xy, _ClipRect);
                #endif

                #ifdef UNITY_UI_ALPHACLIP
                clip (color.a - 0.001);
                #endif
				
				color = limitcolor(color,IN.texcoord);
				color.a *= 1 - saturate( cutconner(IN.localPosition.xy));
                return color;//fixed4(IN.texcoord,0,1);//color;//fixed4(color.a,color.a,color.a,1);
            }
			fixed4 limitcolor(fixed4 color,float2 uv)
			{
				float overxmin = step(uv.x,_OrgionAndSize.x);
				float overxmax = 1 - step(uv.x,_OrgionAndSize.z);
				float overymin = step(uv.y,_OrgionAndSize.y);
				float overymax = 1 - step(uv.y,_OrgionAndSize.w);
				return lerp(color,_BGColor,saturate(overxmin+overxmax+overymin+overymax));
			}
			float cutconner(float2 localPosition)
			{
				float sq3 = sqrt(3);
				float lineX = 0.5;
				float lineY = 0.5 * sq3;
				float d = 0.5 * lineY;
				
				float rightup = 1 - step(dot(localPosition,float2(lineX,lineY)),d);
				float leftup = 1 - step(dot(localPosition,float2(-lineX,lineY)),d);
				float rightdown = 1 - step(dot(localPosition,float2(lineX,-lineY)),d);
				float leftdown = 1 - step(dot(localPosition,float2(-lineX,-lineY)),d);
				float left = 1 - step(dot(localPosition,float2(1,0)),d);
				float right = 1 - step(dot(localPosition,float2(-1,0)),d);
				return rightup+leftup+rightdown+leftdown+left+right;
			}
        ENDCG
        }
    }
}
