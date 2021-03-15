Shader "Unlit/Reflect"
{
    Properties
    {
        _MainTex ("Front", 2D) = "white" {}
		_BACK ("Back", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        //LOD 100

        Pass
        {
			cull back
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };
            sampler2D _MainTex;
            float4 _MainTex_ST;
			float4x4 refMtx;
			float4 n;
			float4 q;
            v2f vert (appdata v)
            {
                v2f o;
				float4 wp = v.vertex;//mul(unity_ObjectToWorld,v.vertex);
				wp = mul(wp,refMtx);
				wp = lerp(wp,v.vertex,step(dot(n,(wp-q)),0));
                //o.vertex = UnityWorldToClipPos(wp);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.vertex = UnityObjectToClipPos(wp);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }

		Pass
        {
			cull front
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };
            sampler2D _BACK;
			float4x4 refMtx;
			float4 n;
			float4 q;
            v2f vert (appdata v)
            {
                v2f o;
				float4 wp = v.vertex;//mul(unity_ObjectToWorld,v.vertex);
				wp = mul(wp,refMtx);
				wp = lerp(wp,v.vertex,step(dot(n,(wp-q)),0));
                o.uv = v.uv;
				o.vertex = UnityObjectToClipPos(wp);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_BACK, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
