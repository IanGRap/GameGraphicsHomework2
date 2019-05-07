Shader "Custom/Tron"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_BaseColor ("Base Color", Color) = (1, 1, 1, 1)
		_RimColor("Rim Color", Color) = (1, 0, 0, 1)
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

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
				float3 normal : NORMAL;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
				float3 normal : NORMAL;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _BaseColor;
			float4 _RimColor;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.normal = v.normal;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				float3 n = normalize(i.normal);
				float3 v = normalize(i.vertex - _WorldSpaceCameraPos);
				if (dot(v, n) == 0) {
					return float4(_RimColor.rgb, 1.0);
				}
				else {
					return float4(_BaseColor.rgb, 1.0);
				}
			}
			ENDCG
		}
	}
}
