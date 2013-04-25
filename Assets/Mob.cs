using UnityEngine;
using System.Collections;

public abstract class Mob : MonoBehaviour {
	
	[HideInInspector]
	public MobFactory factory;
	
	
	[HideInInspector]
	public Vector3 grav;
	[HideInInspector]
	public Vector3 up;
	
	private RaycastHit hit;
	protected bool onGround;
	public float rotSpeed = 0.05f;
	public float gravForce = 20.0f;
	public float moveForce = 40;			
	protected float health = 20;
	
	void Start(){
		grav = new Vector3(transform.position.x, 0, transform.position.z).normalized;
		up = -grav;
	}
	
	void FixedUpdate () {
		grav = new Vector3(transform.position.x, 0, transform.position.z).normalized;
		
		if(!onGround){
			transform.rotation = Quaternion.Slerp(Quaternion.LookRotation(transform.forward, up), Quaternion.LookRotation(transform.forward, -grav), 0.1f);
		}
		else{
			Quaternion dest = Quaternion.LookRotation(Vector3.Cross(transform.right, up), up);
			transform.rotation = Quaternion.Slerp(transform.rotation, dest, rotSpeed);
		}
		up = transform.up;
		
		move ();
		
		rigidbody.AddForce(-up.normalized*gravForce);	

	}
	
	
	public abstract void init(Vector3 vel);
	
	public abstract void move();
	
	void OnCollisionEnter(Collision cx){
		col(cx);
	}
	
	void OnCollisionStay(Collision cx){
		col(cx);
	}
	
	void OnCollisionExit(Collision cx){
		onGround = false;
	}
	
	void col(Collision cx){
		if (cx.collider.CompareTag("Terrain")){
			Vector3 norms = new Vector3(0, 0, 0);
			int size = 0;
			foreach (ContactPoint cp in cx.contacts){
				norms += cp.normal;
				size++;
			}
			up = norms.normalized;
			onGround = true;
		}
		collide(cx);
	}
	
	public virtual void collide(Collision cx){
		
	}
}
