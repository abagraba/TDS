using UnityEngine;
using System.Collections;

public class Projectile : Mob{
	
	
	public float lateralForce = 0;
	public float initialVelocity = 20;
	public float initalHOff = 0;
	
	
	public float lifetime = 10;
	private float life;
	
	
	public override void init(Vector3 vel){
		
		transform.position = transform.position + transform.right*initalHOff;
		rigidbody.velocity = vel + transform.forward*initialVelocity;
	}
	
	public override void move(){
		rigidbody.AddForce(transform.forward*moveForce);
	}
	
}

