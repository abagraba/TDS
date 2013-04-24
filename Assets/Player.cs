using UnityEngine;
using System.Collections;

public class Player : Mob{
	
	public float jumpForce = 500.0f;
	public float moveForce = 60.0f;
	public float gravForce = 20.0f;
	public float rotSpeed = 0.1f;
	public float turnSpeed = 0.05f;
	public float groundMult = 3;
	
	public override void move(){
		//Rotate
		if (Input.GetKey(KeyCode.Q))
			transform.RotateAround(transform.up, -turnSpeed);
		if (Input.GetKey(KeyCode.E))
			transform.RotateAround(transform.up, turnSpeed);
		if(!onGround){
			Vector3 perp = Vector3.Cross(-grav, up);
			transform.rotation = Quaternion.Slerp(Quaternion.LookRotation(transform.forward, -grav), Quaternion.LookRotation(transform.forward, -grav), 0.0001f);
		}
		else{
			Quaternion dest = Quaternion.LookRotation(Vector3.Cross(transform.right, up), up);
			transform.rotation = Quaternion.Slerp(transform.rotation, dest, rotSpeed);
		}
		
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
		rigidbody.AddForce(pos.normalized*moveForce*(onGround?groundMult:1));	
		if (onGround && Input.GetKey(KeyCode.Space)){
			rigidbody.AddForce(-grav.normalized*jumpForce);	
			onGround = false;
		}
		rigidbody.AddForce(grav.normalized*gravForce);	
		Debug.DrawRay(transform.position, up, Color.blue, 15);
	}	
	
}

