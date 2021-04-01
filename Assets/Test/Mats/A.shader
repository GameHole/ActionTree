Shader "TT/A"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest [unity_GUIZTestMode] Lighting Off Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
				float4 local : TEXCOORD1;
            };
			
            sampler2D _MainTex;
			float4 _MainTex_ST;
			float4x4 _world2local;
			float4x4 _localworld;
            v2f vert (appdata v)
            {
                v2f o;
				o.local = mul( _world2local,mul(_localworld, v.vertex));
                o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }


            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                // just invert the colors
                //col.rgb = 1 - col.rgb;
                return col;//fixed4(i.local.xyz,1);
            }
            ENDCG
        }
    }
}
