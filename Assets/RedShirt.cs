using UnityEngine;
using System.Collections;

public class RedShirt : Mob {
	
	public Mob target;
	public float turnSpeed = 0.05f;
	
	public MobFactory firex;
	
	
	public float cooldown = 1;
	private float cool;
	
	
	public override void init(Vector3 vel){
		health = 20;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//they're red shirts.  They don't do much beyond move and shoot.
		move();
		if (cool < 0 ){
			fire();
			cool = cooldown;
		}
		cool -= Time.fixedDeltaTime;
	}
	
	public override void move()
	{
		transform.rotation = Quaternion.LookRotation(Vector3.Cross(transform.right, up), up);
		rigidbody.AddForce(transform.forward*moveForce);	
	}
	
	public void fire()
	{
		//assuming that doing this will make the bullet move in the direction that the Red Shirt is looking
		firex.create(transform.position, transform.rotation, rigidbody.velocity);
	}
	
	public override void collide(Collision cx)
	{
		Debug.Log ("c");
		if (cx.collider.CompareTag("Player"))
			health -= 10;
		if (health <= 0)
			Destroy (gameObject);
	}
	
	
}
