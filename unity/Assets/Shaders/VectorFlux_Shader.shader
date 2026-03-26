Shader "VectorFlux/NeonWireframe"
{
    Properties
    {
        _Color ("Neon Color", Color) = (0, 1, 0.6, 1)
        _Thickness ("Wire Thickness", Range(0.001, 0.5)) = 0.05
        _Emission ("Emission Intensity", Range(0, 10)) = 2.5
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

            float4 _Color;
            float _Thickness;
            float _Emission;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Geometric Grid Logic (Works in Built-in AND URP)
                float2 edge = step(i.uv, _Thickness) + step(1.0 - i.uv, _Thickness);
                float isEdge = saturate(edge.x + edge.y);
                
                return _Color * isEdge * _Emission;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
