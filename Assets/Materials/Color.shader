Shader "Custom/Color" {
	Properties {
		_Color ("Color", Color) = (1, 1, 1, 1)
	}
	SubShader {
	    Pass {
	
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			
			struct v2f {
			    float4 pos : SV_POSITION;
			    float3 color : COLOR0;
			};
			
			float4 _Color;
			
			v2f vert (appdata_base v)
			{
			    v2f o;
			    o.pos = mul (UNITY_MATRIX_MVP, v.vertex);		    
			    o.color = _Color;
			    return o;
			}
			
			half4 frag (v2f i) : COLOR
			{
			    return half4 (i.color, 1);
			}
			ENDCG
	
	    }
	}
Fallback "VertexLit"
} 
