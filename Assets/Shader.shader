Shader "Custom/Shader" {
	Properties {
		_rPos ("Red Position and Falloff", Vector) = (0, 0, 0, 100)
		_gPos ("Green Position and Falloff", Vector) = (0, 1, 0, 0.5)
		_bPos ("Blue Position and Falloff", Vector) = (1, 1, 0, 0.5)
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
			
			float4 _rPos;
			float4 _gPos;
			float4 _bPos;
			
			v2f vert (appdata_base v)
			{
			    v2f o;
			    o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
			    
			    float4 p = o.pos/o.pos.w;
			    
			    float3 dr = p.xyz - _rPos.xyz;
			    float3 dg = p.xyz - _gPos.xyz;
			    float3 db = p.xyz - _bPos.xyz;
			    
			    float rDist = (dr.x*dr.x)+(dr.y*dr.y);
			    float gDist = (dg.x*dg.x)+(dg.y*dg.y);
			    float bDist = (db.x*db.x)+(db.y*db.y);
			    
			    float r = ((_rPos.w*_rPos.w)/rDist);
			    float g = ((_gPos.w*_gPos.w)/gDist);
			    float b = ((_bPos.w*_bPos.w)/bDist);
			    
			    if (r > 1)
			    	r = 1;
			    if (g > 1)
			    	g = 1;
			    if (b > 1)
			    	b = 1;

   			    if (r < 0.2)
			    	r = 0.2;
			    if (g < 0.2)
			    	g = 0.2;
			    if (b < 0.2)
			    	b = 0.2;

			    			    			    
			    o.color = float3(1-r*r, 1-g*g, 1-b*b);
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
