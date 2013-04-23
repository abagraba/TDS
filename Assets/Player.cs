using UnityEngine;
using System.Collections;

public class Player : Mob{
	
	public float jumpForce = 500.0f;
	public float moveForce = 60.0f;
	public float gravForce = 20.0f;
	public float rotSpeed = 0.1f;
	public float turnSpeed = 0.05f;
	
	public override void move(){
		Vector3 pos = new Vector3();
		if (Input.GetKey(KeyCode.W))
			pos += transform.forward;
		if (Input.GetKey(KeyCode.S))
			pos -= transform.forward;
		if (Input.GetKey(KeyCode.A))
			pos -= transform.right;
		if (Input.GetKey(KeyCode.D))
			pos += transform.right;
		rigidbody.AddForce(pos.normalized*moveForce*(onGround?3:1));	
		if (onGround && Input.GetKey(KeyCode.Space)){
			rigidbody.AddForce(-grav.normalized*jumpForce);	
			onGround = false;
		}
		rigidbody.AddForce(grav.normalized*gravForce);	
		
		if (Input.GetKey(KeyCode.Q))
			transform.RotateAround(transform.up, -turnSpeed);
		if (Input.GetKey(KeyCode.E))
			transform.RotateAround(transform.up, turnSpeed);
		Quaternion dest = Quaternion.LookRotation(Vector3.Cross(transform.right, -grav), -grav);
        transform.rotation = Quaternion.Slerp(transform.rotation, dest, rotSpeed);
	}
	
}

