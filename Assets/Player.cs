using UnityEngine;
using System.Collections;

public class Player : Mob{
	
	public float initAngle = 0;
	
	public float jumpvel = 500.0f;
	public float turnSpeed = 0.05f;
		
	public float cooldown = 10;
	private float cool;
	
	public MobFactory fire;
	
	public override void move(){
		if (health > 0)
			userInput();
		cool -= Time.fixedDeltaTime;
	}	
	
	public void userInput(){
	//Rotate
		if (Input.GetKey(KeyCode.Q))
			transform.RotateAround(transform.up, -turnSpeed);
		if (Input.GetKey(KeyCode.E))
			transform.RotateAround(transform.up, turnSpeed);
		
		//Translate	
		Vector3 pos = new Vector3();
		if (Input.GetKey(KeyCode.W))
			pos += transform.forward;
		if (Input.GetKey(KeyCode.S))
			pos -= transform.forward;
		if (Input.GetKey(KeyCode.A))
			pos -= transform.right;
		if (Input.GetKey(KeyCode.D))
			pos += transform.right;
		if (onGround)
			rigidbody.AddForce(pos.normalized*moveForce);	

		if (onGround && Input.GetKey(KeyCode.Space)){
			rigidbody.velocity = rigidbody.velocity + (up.normalized*jumpvel);	
			onGround = false;
		}
		
		if (Input.GetAxis("Fire1")>=1 && (cool < 0)){
			fire.create(transform.position, transform.rotation, rigidbody.velocity);
			cool = cooldown;
		}
			
	}
	
	public override void init(Vector3 vel){
		Vector3 pos = new Vector3(Mathf.Cos(initAngle), transform.position.y, Mathf.Sin(initAngle));
		transform.position = pos;
		transform.rotation = Quaternion.LookRotation(new Vector3(0, 1, 0), -pos);
	}
	
	public override void collide(Collision cx)
	{
		if (cx.collider.CompareTag("Enemy"))
			health -= 1;
	}
	
	
}

