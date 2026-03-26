Shader "VectorFlux/NeonWireframe"
{
    Properties
    {
        _Color ("Main Color", Color) = (0, 1, 0.6, 1)
        _WireThickness ("Wire Thickness", Range(0, 0.1)) = 0.02
        _Emission ("Emission Intensity", Range(0, 10)) = 2.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "RenderPipeline"="UniversalPipeline" }
        LOD 100

        Pass
        {
            Name "ForwardLit"
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            float4 _Color;
            float _WireThickness;
            float _Emission;

            Varyings vert(Attributes input)
            {
                Varyings output;
                output.positionCS = TransformObjectToHClip(input.positionOS.xyz);
                output.uv = input.uv;
                return output;
            }

            float4 frag(Varyings input) : SV_Target
            {
                // Simple edge highlights (pseudo-wireframe via UV)
                float edge = step(input.uv.x, _WireThickness) + step(1.0 - input.uv.x, _WireThickness) +
                             step(input.uv.y, _WireThickness) + step(1.0 - input.uv.y, _WireThickness);
                
                return _Color * saturate(edge) * _Emission;
            }
            ENDHLSL
        }
    }
}
