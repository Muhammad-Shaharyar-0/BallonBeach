Shader "CurvedShader" {
	Properties{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.0
		_Metallic("Metallic", Range(0,1)) = 0.0

	}
		SubShader{
		Tags{ "RenderType" = "Opaque" }
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		// Curved world: Define the vertex function
#pragma surface surf Standard fullforwardshadows vertex:vert addshadow

		// Use shader model 3.0 target, to get nicer looking lighting
#pragma target 3.0

		sampler2D _MainTex;

	struct Input {
		float2 uv_MainTex;
	};

	half _Glossiness;
	half _Metallic;
	fixed4 _Color;
	void surf(Input IN, inout SurfaceOutputStandard o) {
		fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
		o.Albedo = c.rgb;
		o.Metallic = _Metallic;
		o.Smoothness = _Glossiness;
		o.Alpha = c.a;
	}


	// Curved world: Vertex displacement

	float _Curvature;
	float _Trimming;

	void vert(inout appdata_full v) {
		v.vertex = mul(unity_ObjectToWorld, v.vertex);
		float dist = distance(_WorldSpaceCameraPos, v.vertex);
		v.vertex.y -= pow(dist, _Curvature) * _Trimming / 100;
		v.vertex = mul(unity_WorldToObject, v.vertex);
	}

	ENDCG
	}
		FallBack "Standard"
}