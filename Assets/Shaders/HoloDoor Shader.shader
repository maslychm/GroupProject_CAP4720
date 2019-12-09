// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/HoloDoor Shader"
{
    Properties
    {
        _Color ("Color (RGBA)", Color) = (1,1,1,1)
        _MainTex ("Holo Texture", 2D) = "white" {}
        _VignTex ("Vignette Texture", 2D) = "white" {}
        
    }
    SubShader
    {
        Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha
        Cull front
        LOD 100
        Pass
			{
                CGPROGRAM

                #pragma vertex vert alpha
                #pragma fragment frag alpha

                #include "UnityCG.cginc"

                struct vertexInput {
                    float4 vertex : POSITION;
                    float2 texcoord : TEXCOORD0;
                };

                struct vertexOutput {
                    float4 position: SV_POSITION;
                    half2 texcoord: TEXCOORD0;
                };

                sampler2D _MainTex;
                sampler2D _VignTex;
                float4 _MainTex_ST;
                float4 _Color;

                vertexOutput vert(vertexInput i){
                    vertexOutput o;
                    o.position = UnityObjectToClipPos(i.vertex);
                    i.texcoord.x = 1 - i.texcoord.x;
                    o.texcoord = TRANSFORM_TEX(i.texcoord, _MainTex);
                    return o;
                }

                float4 frag(vertexOutput i) : SV_Target{
                    float timeDisp = _Time % 1;
                    float sinTimeDisp = (_SinTime.w * 1) % 1;
                    float4 vigColor = tex2D(_VignTex, i.texcoord) * sinTimeDisp;
                    // float4 texColor = tex2Dlod(_MainTex, 
                    //     float4(0.0, i.texcoord.y, 0.0, 0.0) - timeDisp) + vignColor;
                    float4 texColor = tex2Dlod(_MainTex, 
                        float4(0.0, i.texcoord.y, 0.0, 0.0) - timeDisp);
                    _Color *= texColor;
                    return _Color;
                }

                // fixed4 frag (vertexOutput i) : SV_Target
                // {
                //     fixed4 col = tex2D(_MainTex, i.texcoord) * _Color; // multiply by _Color
                //     return col;
                // }


                ENDCG
            }
    }
}
