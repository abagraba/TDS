using UnityEngine;
using System.Collections;

public class ShaderControl : MonoBehaviour {

	public Material material;
	
	public float fr = 1;
	public float fg = 2;
	public float fb = -1;
	public float ar = 1;
	public float ag = 1;
	public float ab = 1;
	private float t;
	
	
	void Update () {
		t += Time.deltaTime;
		material.SetVector("_rPos", new Vector4(ar*Mathf.Cos(2*Mathf.PI*fr*t), ar*Mathf.Sin(2*Mathf.PI*fr*t), 0, 1));
		material.SetVector("_gPos", new Vector4(ag*Mathf.Cos(2*Mathf.PI*fg*t), ag*Mathf.Sin(2*Mathf.PI*fg*t), 0, 1));
		material.SetVector("_bPos", new Vector4(ab*Mathf.Cos(2*Mathf.PI*fb*t), ab*Mathf.Sin(2*Mathf.PI*fb*t), 0, 1));
		
		
	}
}
