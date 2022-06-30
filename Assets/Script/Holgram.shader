Shader "Custom/Holgram"
{
	Properties{
		_Color("Color",color) = (0,0.5,0.5,0)
		_RimPow("Rim STR",Range(0,50)) = 3.0

	}
		SubShader{
		Tags{"Queue" = "Transparent"}

		pass {
		ZWrite off
			ColorMask 0
		 }


		CGPROGRAM
#pragma surface surf Lambert alpha:fade
		sampler2D _MainTex;

		struct Input {
			float3 viewDir;
		};

	fixed4 _Color;
	float _RimPow;

	void surf(Input IN, inout SurfaceOutput o) {
		half Rim = 1 - saturate(dot(normalize(IN.viewDir), o.Normal));
		o.Emission = _Color.rgb*pow(Rim, _RimPow);
		o.Alpha = pow(Rim, _RimPow);
	}
	ENDCG


	    }
	Fallback"Diffuse"
}
