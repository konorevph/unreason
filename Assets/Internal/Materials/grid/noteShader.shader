Shader "Custom/BlinkingShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BlinkColor ("Blink Color", Color) = (1,1,1,1)
        _BlinkSpeed ("Blink Speed", Float) = 1.0
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

            struct appdata_t
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
            float4 _BlinkColor;
            float _BlinkSpeed;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float4 frag (v2f i) : SV_Target
            {
                float time = _Time.y * _BlinkSpeed;
                float alpha = abs(sin(time)); // Используем синус для мигания
                float4 texColor = tex2D(_MainTex, i.uv);
                return texColor * _BlinkColor * alpha; // Умножаем цвет текстуры на цвет мигания и альфа
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
