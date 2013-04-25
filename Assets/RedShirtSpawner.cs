using UnityEngine;
using System.Collections;

public class RedShirtSpawner : MonoBehaviour {
	
	private float timer;
	

	// Use this for initialization
	void Start () {
		timer = 5;
	}
	
	// Update is called once per frame
	void Update () {
		//every 5 seconds, make a new Red Shirt
		timer -= Time.deltaTime;
		if (timer <= 0)
		{
			timer = 5;
			makeMook ();
		}
	}
	
	void makeMook()
	{
		RedShirt jenkins = new RedShirt();
		jenkins.transform.position = this.transform.position;
	}
}
