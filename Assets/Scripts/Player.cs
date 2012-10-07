using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		collider.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("w") && transform.position.z < 4.5F) {
			transform.Translate(new Vector3(0, 0, 0.5F));
		}	
		if(Input.GetKeyDown("a") && transform.position.x > -4.5F) {
			transform.Translate(new Vector3(-0.5F, 0, 0));
		}
		if(Input.GetKeyDown("d") && transform.position.x < 4.5F) {
			transform.Translate(new Vector3(0.5F, 0, 0));
		}
		if(Input.GetKeyDown("s") && transform.position.z > -4.5F) {
			transform.Translate(new Vector3(0, 0, -0.5F));
		}
		//Debug.Log(transform.position);
	}

	void FixedUpdate() {

	}

	void OnCollisionEnter(Collision collision) {
		Debug.Log("Shit, bro.");
	}
}
