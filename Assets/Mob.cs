using UnityEngine;
using System.Collections;

public abstract class Mob : MonoBehaviour {

	private RaycastHit hit;
	public Vector3 grav;
	protected bool onGround;
	protected Vector3 up;
	
	void Start(){
		grav = new Vector3(transform.position.x, 0, transform.position.z).normalized;
		up = -grav;
	}
	
	void FixedUpdate () {
		grav = new Vector3(transform.position.x, 0, transform.position.z).normalized;
		move ();
	}
		
	public abstract void move();
	
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
		if (cx.collider.CompareTag("Terrain")){
			Vector3 norms = new Vector3(0, 0, 0);
			int size = 0;
			foreach (ContactPoint cp in cx.contacts){
				norms += cp.normal;
				size++;
			}
			up = norms/size;
			onGround = true;
		}
	}
}
