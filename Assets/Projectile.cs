using UnityEngine;
using System.Collections;

public class Projectile : Mob{
	
	
	public float lateralForce = 0;
	public float initialVelocity = 20;
	public float initalHOff = 0;
	
	
	public float lifetime = 10;
	private float life;
	
	
	public override void init(Vector3 vel){
		
		transform.position = transform.position + transform.right*initalHOff + transform.up * 0.5f;
		rigidbody.velocity = vel + transform.forward*initialVelocity;
		life = lifetime;
	}
	
	public override void move(){
		life -= Time.fixedDeltaTime;
		if (life < 0)
			factory.kill(gameObject);
		rigidbody.AddForce(transform.forward*moveForce);
	}
	
}

