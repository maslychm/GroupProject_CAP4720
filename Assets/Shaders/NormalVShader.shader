Shader "Unlit/NormalVShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
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
				float3 normal :NORMAL;
            };

            struct v2f
			{
                float4 vertex : SV_POSITION;
				float3 color : COLOR;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
				float3 worldNormal = UnityObjectToWorldNormal(v.normal);
				worldNormal = (normalize(worldNormal) + 1) / 2;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.color = worldNormal;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                return float4(i.color, 1.0);
            }
            ENDCG
        }
    }
}
