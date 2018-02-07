Shader "Unlit/ColoredSprite"
{
	Properties
	{
		[PerRendererData] _MainTex ("Texture", 2D) = "white" {}
    [PerRendererData] _Color("Tint", Color) = (1,1,1,1)
    _TwinkleColor ("Twinkle Color", Color) = (1,1,1,1)
    _Twinkle ("Twinkle", Range(0.0, 1.0)) = 0.0
    
	}
	SubShader
	{
		Tags{
      "Queue" = "Transparent"        
      "IgnoreProjector" = "True"    
      "RenderType" = "Transparent"
      "PreviewType" = "Plane"        
      "CanUseSpriteAtlas" = "True"
    }
    
    Cull Off
    Lighting Off
    ZWrite Off
    Fog { Mode Off }
    Blend SrcAlpha OneMinusSrcAlpha
    
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile DUMMY PIXELSNAP_ON
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION ;
        float4 color : COLOR ;
				float2 uv : TEXCOORD0 ;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
        fixed4 color : COLOR ;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
      fixed4 _Color;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
        o.color = v.color * _Color ;
        
				return o;
			}
			
      fixed _Twinkle;
      fixed4 _TwinkleColor ;
      
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv) * i.color;
        
        // Result
        fixed4 res = lerp(col, _TwinkleColor, _Twinkle) ;
        res.a = col.a ;
        
				return res;
			}
			ENDCG
		}
	}
  Fallback "Sprites/Default"
}
