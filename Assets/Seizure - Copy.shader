Shader "Custom/Seizurex" {
	Properties {
		_rPos ("Red Position and Falloff", Vector) = (0, 0, 0, 100)
		_gPos ("Green Position and Falloff", Vector) = (0, 1, 0, 0.5)
		_bPos ("Blue Position and Falloff", Vector) = (1, 1, 0, 0.5)
		_rf ("Red Frequency", Float) = 1
		_gf ("Gren Frequency", Float) = 1
		_bf ("Blue Frequency", Float) = 1
		_omega ("Omega", Float) = 1
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
			
			float3 _rPos;
			float3 _gPos;
			float3 _bPos;
			float _rf;
			float _gf;
			float _bf;
			float _omega;
			
			
			v2f vert (appdata_base v)
			{
			    v2f o;
			    o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
			    
			    float4 p = mul (UNITY_MATRIX_MV, v.vertex);
			    
			    
			    float3 dr = p.xyz - _rPos.xyz;
			    float3 dg = p.xyz - _gPos.xyz;
			    float3 db = p.xyz - _bPos.xyz;
			    
			    
			    float rDist = (dr.x*dr.x)+(dr.y*dr.y)+(dr.z*dr.z);
			    float gDist = (dg.x*dg.x)+(dg.y*dg.y)+(dg.z*dg.z);
			    float bDist = (db.x*db.x)+(db.y*db.y)+(db.z*db.z);
			    
			    float pulse = 0.5+0.5*sin(_omega*_Time);
			    float r = 0.5*(sin(rDist)+sin(_rf*pulse))+0.5;
				float g = 0.5*(sin(gDist)+sin(_gf*pulse))+0.5;
				float b = 0.5*(sin(bDist)+sin(_bf*pulse))+0.5;			
			    			    			    
			    o.color = float3(r, g, b);
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
