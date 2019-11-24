Shader "Custom/CubeColorSurface"
{
    Properties
    {
        _ColorClose ("Color Close", Color) = (0,1,0,1)
		_ColorFar ("Color Far", Color) = (1,0,0,1)
		_ObjPos ("ObjPos", Vector) = (0,0,0,0)
		_CorePos ("ObjPos", Vector) = (0,0,0,0)
		_Scale ("Scale", Range(0,100)) = 20.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows
        #pragma target 3.0

		struct Input
		{
			float4 color : COLOR;
		};

		float4 _ObjPos;
		float4 _CorePos;
		float _Scale;
		fixed4 _ColorClose;
		fixed4 _ColorFar;

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
			float3 dist3 = _CorePos - _ObjPos;
			float dist = length(dist3);
			float3 lerpedColor = lerp(_ColorClose, _ColorFar, dist / _Scale);
            o.Albedo = lerpedColor;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
