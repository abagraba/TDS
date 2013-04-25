using UnityEngine;
using System.Collections;

public class RedShirtSpawner : MobFactory {
	
	private float timer;
	public float cooldown = 5;
	
	public float minRange;
	public float maxRange;

	// Use this for initialization
	void Start () {
		timer = cooldown;
	}
	
	// Update is called once per frame
	void Update () {
		//every 5 seconds, make a new Red Shirt
		timer -= Time.deltaTime;
		if (timer <= 0)
		{
			timer = cooldown;
			makeMook ();
		}
	}
	
	void makeMook()
	{
		float theta = Random.value;
		Vector3 pos = new Vector3(Mathf.Cos(theta), Random.Range(minRange, maxRange), Mathf.Sin(theta));
		create(pos, Quaternion.LookRotation(new Vector3(0, 1, 1)), new Vector3(0, 0, 0));
	}
}
