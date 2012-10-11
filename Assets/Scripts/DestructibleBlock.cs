using UnityEngine;
using System.Collections;

public class DestructibleBlock : WallBlock {
	
	public int health;
	
	// Use this for initialization
	void Start () {
		health = 10; // or whatever
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0) {
			Destroy(gameObject);
		}
	}
}
