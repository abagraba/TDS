using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {
	
	public GameObject target;
	public float verticalOffset;
	public float horizontalOffset;
	public float distance;
	public float lookDistance;
	public float rotSpeed = 0.1f;
	
	void Update () {
		transform.position = target.transform.position;
		transform.position += verticalOffset*target.transform.up;
		transform.position += horizontalOffset*target.transform.right;
		transform.position -= distance*target.transform.forward;
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.transform.position+target.transform.forward*lookDistance-transform.position), rotSpeed);
	}
}
