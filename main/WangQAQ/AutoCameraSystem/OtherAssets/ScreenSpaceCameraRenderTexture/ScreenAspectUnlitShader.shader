Shader "Unlit/ScreenAspectUnlitShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags {
        "Queue"="AlphaTest"
        "RenderType"="TransparentCutout"
        "IgnoreProjector"="True" 
        }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o, o.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                float aspect = _ScreenParams.x / _ScreenParams.y;
                if (aspect > 1.0)
                {
                    if (abs(i.uv.y - 0.5) > 0.5 / aspect)
                    {
                        //col.rgb = 0.5 + 0.5 * (col.rgb - 0.5);
                        clip(-1);
                    }
                }
                else
                {
                    if (abs(i.uv.x - 0.5) > 0.5 * aspect)
                    {
                        //col.rgb = 0.5 + 0.5 * (col.rgb - 0.5);
                        clip(-1);
                    }
                }
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}