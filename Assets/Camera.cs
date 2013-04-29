using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Camera : MonoBehaviour {
	
	public Mob target;
	public float verticalOffset;
	public float horizontalOffset;
	public float distance;
	public float lookDistance;
	public float rotSpeed = 0.1f;
	
	
	void OnPreRender() {
       // GL.wireframe = true;
    }
    void OnPostRender() {
        GL.wireframe = false;
    }
	
	void FixedUpdate () {
		transform.position = target.transform.position;
		transform.position -= verticalOffset*target.grav;
		transform.position += horizontalOffset*target.transform.right;
		transform.position -= distance*target.transform.forward;
		Vector3 lookDirection = target.transform.position+Vector3.Cross(target.transform.right, target.up).normalized*lookDistance-transform.position;
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.transform.forward, -target.grav), rotSpeed);
	}
}
