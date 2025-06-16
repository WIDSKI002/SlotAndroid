Shader "Custom/SpriteBlur"
{
    Properties
    {
        _MainTex ("Sprite Texture", 2D) = "white" {}
        _BlurAmount ("Blur Amount", Range(0, 100)) = 20
    }
    SubShader
    {
        Tags {"Queue"="Transparent" "RenderType"="Transparent"}
        LOD 100

        Pass
        {
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _BlurAmount;

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

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv;
                float2 texelSize = _BlurAmount / _ScreenParams.xy;
                
                fixed4 col = fixed4(0,0,0,0);
                float totalWeight = 0;
                

                for(int x = -6; x <= 6; x++)
                {
                    for(int y = -4; y <= 4; y++)
                    {
                        float2 offset = float2(x, y) * texelSize;
                        float weight = exp(-(x*x + y*y) / 800.0);
                        col += tex2D(_MainTex, uv + offset) * weight;
                        totalWeight += weight;
                    }
                }
                
                return col / totalWeight;
            }
            ENDCG
        }
    }
}
