using UnityEngine;
using System.Collections;

public abstract class Mob : DontGoThroughThings {

	private RaycastHit hit;
	protected Vector3 grav;
	protected bool onGround;
	
	void Start () {
		grav = -transform.up;
	}
		
	
	void OnCollisionEnter(Collision cx){
		collide(cx);
	}
	
	void OnCollisionStay(Collision cx){
		collide(cx);
	}
	
	void OnCollisionExit(Collision cx){
		onGround = false;
	}
	
	void collide(Collision cx){
		Vector3 norms = new Vector3(0, 0, 0);
		int size = 0;
		foreach (ContactPoint cp in cx.contacts){
			norms += cp.normal;
			size++;
		}
		grav = -norms/size;
		onGround = true;
	}
}
