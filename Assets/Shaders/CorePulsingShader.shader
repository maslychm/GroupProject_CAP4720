Shader "Unlit/CorePulsingShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
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
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f IN) : SV_Target
            {
				float4 texCol = tex2D(_MainTex, IN.uv + float2(
					(IN.vertex.x / 50 + _Time[1]) / 100, 0));
				float4 lerped = lerp(float4(0, 0, 1, 1), float4(.5, .5, 1, 1), sin(_Time[3])*.5 + .5);
				float4 newC = float4(0,1,1,1) * (sin(_Time[3])*.5 + .5);
				return texCol * lerped;
            }
            ENDCG
        }
    }
}
