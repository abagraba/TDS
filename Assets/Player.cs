using UnityEngine;
using System.Collections;

public class Player : Mob{
	
	public float jumpForce = 500.0f;
	public float turnSpeed = 0.05f;
	
	public override void move(){
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
			rigidbody.AddForce(-grav.normalized*jumpForce);	
			onGround = false;
		}
	}	
	
	public override void init(Vector3 vel){
	
	}
	
}

