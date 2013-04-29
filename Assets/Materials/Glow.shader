Shader "Custom/Glow" {
	Properties {
		_Col ("Color", Color) = (1, 1, 1, 1)
		_Pos ("Position", Vector) = (0, 0, 0, 0)
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
			
			float3 _Pos;
			float4 _Col;
			
			
			
			v2f vert (appdata_base v)
			{
			    v2f o;
			    o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
			    
			    float4 p = v.vertex;
			    
			    float3 r = p.xyz - _Pos.xyz;
			    
			    float rr = r.x*r.x+r.y*r.y+r.z*r.z;
			    rr /= _Pos.z*_Pos.z;    
			        
				o.color = _Col;
			    if (rr > 1){
			    	float dr = 0.5 + (0.5/rr);
			    	o.color = _Col*dr;
			    }
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
