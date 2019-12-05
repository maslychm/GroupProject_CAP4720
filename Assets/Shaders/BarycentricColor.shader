Shader "Custom/BarycentricColor"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex("Main Texture", 2D) = "white" {}
		// Add additional Properties here.
		_DispTex("Displacement Texture", 2D) = "white" {}
		_ObjPos("ObjPos", Vector) = (0,0,0,0)
		_CorePos("ObjPos", Vector) = (0,0,0,0)
		_MaxDist("Maximum Distance", Range(0,50)) = 20.0
		_MaxDisplacement("Max Displacement", Float) = 5.0
	}
		SubShader
		{
			Pass
			{
				 CGPROGRAM

				 #pragma vertex vert
				 #pragma fragment frag

				 sampler2D _MainTex;
				 float _MaxDisplacement;
				 sampler2D _DispTex;
				 float _MaxDist;
				 fixed4 _Color;
				 float4 _ObjPos;
				 float4 _CorePos;

				 struct vertexInput {
					 float4 vertex : POSITION;
					 float3 normal : NORMAL;
					 float4 texcoord : TEXCOORD0;
				 };

				 struct vertexOutput {
					 float4 position: SV_POSITION;
					 float4 texcoord: TEXCOORD0;
				 };

				 vertexOutput vert(vertexInput i) {
					 vertexOutput o;
					 float3 dist3 = _CorePos - _ObjPos;
					 float dist = length(dist3);
					 float timeDisp = _Time % 1;
					float4 dispTexColor = tex2Dlod(
						_DispTex, 
						float4(
							i.texcoord.x + _Time[0],
							i.texcoord.y,
							0.0, 
							0.0
						)
					);
				

					 float disp = dispTexColor.b / _MaxDisplacement * dist;

					 float displ = disp * 5;
					 float4 newVertPos = i.vertex + float4(i.normal * disp, 0.0) / 10;
					 o.position = UnityObjectToClipPos(newVertPos);
					//  o.position = UnityObjectToClipPos(i.vertex);
					//  o.color = displ * _Color;
					 o.texcoord = i.texcoord;
					 return o;
				 }

				 float4 frag(vertexOutput i) : COLOR
				 {
					 float3 dist3 = _CorePos - _ObjPos;
					 float dist = length(dist3);

					 float timeDisp = _Time % 1;
					 float4 texColor = tex2Dlod(_MainTex, float4(i.texcoord.xy, 0.0, 0.0) + timeDisp);
					 if (dist > _MaxDist) {
						 dist = _MaxDist;
					 }
					 float distDegree = (dist / _MaxDist);
					 
					 float texTrans = distDegree;
					 texColor *= texTrans;
					 float r_val = distDegree;
					 float g_val = (1 - r_val);
				
					 _Color.r = r_val;
					 _Color.g = g_val;
					 _Color.b = 0.0;
					 return _Color + texColor;
				 }
				 ENDCG
		}
    }
}
