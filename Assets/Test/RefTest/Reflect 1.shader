Shader "MyShader/Reflect1"
{
    Properties
    {
        _MainTex ("Front", 2D) = "white" {}
		_BACK ("Back", 2D) = "white" {}
		axis("Axis",vector)=(0,0,0,0)
		q("center",vector) = (0,0,0,0)
		r("R",float) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        //LOD 100

        Pass
        {
			cull off
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
				float3 normal : NORMAL;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };
            sampler2D _MainTex;
            float4 _MainTex_ST;
			float4 axis;
			float4 q;
			float r;
            v2f vert (appdata v)
            {
                v2f o;
				float3 localP = v.vertex.xyz;
				float3 naxis = normalize(axis.xyz);
				float3 dif = localP - q.xyz;
				float3 difpx = dot(dif, naxis)* naxis;
				float3 cosdir = dif - difpx;
				float costh = dot(normalize(cosdir), v.normal);
				float sinth = sqrt(1 - costh * costh);
				localP = q + difpx + normalize(cosdir) * distance(cosdir, float3(0, 0, 0))*sinth;
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.vertex = UnityObjectToClipPos(float4(localP, 1));
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
    }
}
