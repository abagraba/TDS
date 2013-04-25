using UnityEngine;
using System.Collections.Generic;

public class MobFactory : MonoBehaviour {
	
	LinkedList<GameObject> active = new LinkedList<GameObject>();
	LinkedList<GameObject> dead = new LinkedList<GameObject>();
	
	public Mob[] args;
	

	public void create(Vector3 pos, Quaternion rot, Vector3 vel){
		foreach (Mob o in args){
			LinkedListNode<GameObject> n = dead.First;
			Projectile p;
			if (n != null){
				p = n.Value.GetComponent<Projectile>();
				p.transform.position = pos;
				p.transform.rotation = rot;
				dead.RemoveFirst();
			}
			else{
				p = ((GameObject)Instantiate(o.gameObject, pos, rot)).GetComponent<Projectile>();
				p.GetComponent<Mob>().factory = this;
			}
			p.init(vel);
			active.AddLast(p.gameObject);
			p.gameObject.SetActive(true);
		}
	}
	
	public void kill(GameObject o){
		active.Remove(o);
		dead.AddLast(o);
		o.SetActive(false);
	}
	
	
}
