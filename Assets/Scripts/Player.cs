using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public bool hasRed;
	public bool hasGreen;
	public bool hasBlue;
	public Color colorPainted; // the color that the player is currently painted
	public Color colorShooting; // the color that the player is currently shooting


	private Vector3 forward = new Vector3(0, 0, 0.5F);
	private Vector3 backward = new Vector3(0, 0, -0.5F);
	private Vector3 left = new Vector3(-0.5F, 0, 0);
	private Vector3 right = new Vector3(0.5F, 0, 0);

	// Use this for initialization
	void Start () {
		collider.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("w") && transform.position.z < 4.5F) {
			if(!GameManager.CheckPosition(transform.position + forward))
				transform.Translate(forward);
		}	
		if(Input.GetKeyDown("a") && transform.position.x > -4.5F) {
			if(!GameManager.CheckPosition(transform.position + left))
				transform.Translate(left);
		}
		if(Input.GetKeyDown("d") && transform.position.x < 4.5F) {
			if(!GameManager.CheckPosition(transform.position + right))
				transform.Translate(right);
		}
		if(Input.GetKeyDown("s") && transform.position.z > -4.5F) {
			if(!GameManager.CheckPosition(transform.position + backward))
				transform.Translate(backward);
		}
		//Debug.Log(transform.position);
	}

	void FixedUpdate() {

	}

	void OnCollisionEnter(Collision collision) {
		Debug.Log("Shit, bro.");
		
	}
}
