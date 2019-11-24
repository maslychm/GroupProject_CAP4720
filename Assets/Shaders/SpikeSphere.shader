Shader "Vertex Displacement" 
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Main Texture", 2D) = "white" {}
		_DisplacementTex("Displacement Texture", 2D) = "white" {}
		_MaxDisplacement("Max Displacement", Float) = 5.0
		_ObjPos("ObjPos", Vector) = (0,0,0,0)
		_CorePos("ObjPos", Vector) = (0,0,0,0)
	}

	SubShader
	{
		Pass
		{
			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag

			uniform sampler2D _MainTex;
			uniform sampler2D _DisplacementTex;
			uniform float _MaxDisplacement;
			fixed4 _Color;
			float4 _ObjPos;
			float4 _CorePos;

			struct vertexInput {
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 texcoord : TEXCOORD0;
			};

			struct vertexOutput {
				float4 position : SV_POSITION;
				float4 texcoord : TEXCOORD0;
				fixed4 color : COLOR;
			};

			vertexOutput vert (vertexInput i) {
				vertexOutput o;

				float3 dist3 = _CorePos - _ObjPos;
				float dist = length(dist3);

				// Get color from displacement map, and convert to float from 0 to _MaxDisplacement
				float4 dispTexColor = tex2Dlod(_DisplacementTex, float4(i.texcoord.xy, 0.0, 0.0));
				
				// Diplace by G direction times _MaxDisplacement
				float displacement = dispTexColor.b / _MaxDisplacement * dist / 5;
				
				// Scale a value for usage in color
				float displ = displacement * 5;

				// Displace vertices along surface normal vector
				float4 newVertexPos = i.vertex + float4(i.normal * displacement, 0.0);

				// Output data            
				o.position = UnityObjectToClipPos(newVertexPos);
				o.texcoord = i.texcoord;
				o.color = fixed4(displ, displ, displ, displ);
				return o;
			}

			float4 frag(vertexOutput i) : COLOR
			{
				return i.color.x * _Color;
			}
			ENDCG
		}
	}
}