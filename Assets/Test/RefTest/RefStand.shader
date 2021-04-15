Shader "Custom/RefStand"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
		_BACK("Back (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque"  "DisableBatching" = "True"  }
        LOD 200
		cull back
        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows vertex:vert addshadow 

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;



        struct Input
        {
            float2 uv_MainTex;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;
		float4x4 refMtx;
		float4 n;
		float4 q;
        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)
		void vert(inout appdata_full v, out Input o) {
			UNITY_INITIALIZE_OUTPUT(Input, o);//ref: http://forum.unity3d.com/threads/what-does-unity_initialize_output-do.186109/

			float4 wp = v.vertex;//mul(unity_ObjectToWorld,v.vertex);
			wp = mul(wp, refMtx);
			float isRef = step(dot(n, (wp - q)), 0);
			wp = lerp(wp, v.vertex, isRef);
			v.vertex = wp;
			float refN = 2 * dot(n, v.normal)*n - v.normal;
			v.normal = lerp(refN, v.normal, isRef);
		}
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG

		cull front
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows vertex:vert addshadow 

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _BACK;



		struct Input
		{
			float2 uv_BACK;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		float4x4 refMtx;
		float4 n;
		float4 q;
		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
			UNITY_INSTANCING_BUFFER_END(Props)
			void vert(inout appdata_full v, out Input o) {
			UNITY_INITIALIZE_OUTPUT(Input, o);//ref: http://forum.unity3d.com/threads/what-does-unity_initialize_output-do.186109/

			float4 wp = v.vertex;//mul(unity_ObjectToWorld,v.vertex);
			float4 bn = -n;
			float3 pbn = -v.normal;
			float isRef = step(dot(bn, (wp - q)), 0);
			wp = lerp(wp, v.vertex, isRef);
			v.vertex = wp;
			float refN = 2 * dot(bn, pbn)*bn - pbn;
			v.normal = lerp(refN, pbn, isRef);
		}
		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D(_BACK, IN.uv_BACK) * _Color;
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
    }
    FallBack "Diffuse"
}
