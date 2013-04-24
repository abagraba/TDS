using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Camera : MonoBehaviour {
	
	public GameObject target;
	public float verticalOffset;
	public float horizontalOffset;
	public float distance;
	public float lookDistance;
	public float rotSpeed = 0.1f;
	
	
	void OnPreRender() {
        GL.wireframe = true;
    }
    void OnPostRender() {
        GL.wireframe = false;
    }
	
	void Update () {
		transform.position = target.transform.position;
		transform.position += verticalOffset*target.transform.up;
		transform.position += horizontalOffset*target.transform.right;
		transform.position -= distance*target.transform.forward;
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.transform.position+target.transform.forward*lookDistance-transform.position), rotSpeed);
	}
}
