using UnityEngine;
using System.Collections;

public class Projectile : Mob{

	public float moveForce = 40;			

	
	public override void move(){
		rigidbody.AddForce(transform.forward*moveForce);
	}
	
}

