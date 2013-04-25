using UnityEngine;
using System.Collections;

public class RedShirt : Mob {
	
	public float moveForce = 60.0f;
	public float turnSpeed = 0.05f;
	public int health = 20;
	
	// Use this for initialization
	void Start () {
	
	}
	
	public override void init(Vector3 vel){
		
	}
	
	// Update is called once per frame
	void Update () {
		//they're red shirts.  They don't do much beyond move and shoot.
		var distance = Vector3.Distance(this.transform.position, GameObject.Find ("Player").transform.position);
		if (distance > 5)
			move();
		if (distance < 20)
			fire();
	}
	
	public override void move()
	{
		this.transform.LookAt (GameObject.Find("Player").transform.position);
		Vector3 pos = new Vector3();
		
		transform.position = Vector3.MoveTowards (this.transform.position, GameObject.Find ("Player").transform.position, moveForce * Time.deltaTime);
	}
	
	public void fire()
	{
		//assuming that doing this will make the bullet move in the direction that the Red Shirt is looking
		Projectile bullet = new Projectile();
		bullet.move ();
	}
	
	public void OnCollisionEnter()
	{
		health -= 10;
	}
	
	public void OnCollisionExit()
	{
		
	}
}
