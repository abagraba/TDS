using UnityEngine;
using System.Collections;

public class ShaderControl : MonoBehaviour {

	public Material[] materials;
	public Mob target;
	
	public float fallOff = 1;
	private float t;
	
	
	void FixedUpdate () {
		t += Time.fixedDeltaTime;
		foreach (Material material in materials)
			material.SetVector("_Pos", new Vector4(target.transform.position.x, target.transform.position.y, target.transform.position.z, fallOff));
		
		
	}
}
