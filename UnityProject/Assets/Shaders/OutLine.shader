Shader "Custom/OutLine" 
{
	Properties 
	{
		_Color ("Color", Color) = (1,1,1,1)
		_RimWidth("RimWidth",Range(0.5,8.0)) = 3
	}

	SubShader 
	{
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert
		#pragma target 3.0

		struct Input 
		{
			float3 viewDir;
		};

		float4 _Color;
		float  _RimWidth;

		void surf (Input IN, inout SurfaceOutput o) 
		{
			o.Albedo  = _Color;
			half rim  = 1.0 - saturate(dot(normalize(IN.viewDir),o.Normal));
			half rim2 = pow(rim, _RimWidth);
			half rim3;

			if(rim2 < 0.5)
			{
				rim3 = 1.0;
			}
			else
			{
				rim3 = 0.0;
			}

			o.Albedo *= rim3;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
