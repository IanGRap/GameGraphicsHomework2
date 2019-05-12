Shader "Custom/Rim2"
{
	Properties
	{
		_RimColor("Rim Color", Color) = (1, 0, 0, 1)
		_BaseColor("Base Color", Color) = (0, 0, 0, 1)
		_Scale("Scale", Float) = 1.5
	}
	SubShader
	{
		cull front

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
			};

			float4 _RimColor;
			float _Scale;

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex + normalize(v.normal) * _Scale);
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				return _RimColor;
			}
			ENDCG
		}

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
			};

			float4 _BaseColor;

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				return _BaseColor;
			}
			ENDCG
		}
	}
}
