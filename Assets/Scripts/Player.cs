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

	private int colorCount = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("w") && transform.position.z < 4.5F) {
			if(!GameManager.CheckPlayerPosition(transform.position + forward))
				transform.Translate(forward);
		}	
		if(Input.GetKeyDown("a") && transform.position.x > -4.5F) {
			if(!GameManager.CheckPlayerPosition(transform.position + left))
				transform.Translate(left);
		}
		if(Input.GetKeyDown("d") && transform.position.x < 4.5F) {
			if(!GameManager.CheckPlayerPosition(transform.position + right))
				transform.Translate(right);
		}
		if(Input.GetKeyDown("s") && transform.position.z > -4.5F) {
			if(!GameManager.CheckPlayerPosition(transform.position + backward))
				transform.Translate(backward);
		}
		
		if(Input.GetKeyDown("q")) {
			// super-janky code for cycling through available colors
			switch(colorCount) {
				// if player is currently white
				case 0: if(hasRed) {
						renderer.material.color = Color.red;
						colorCount = 1;
						break;
					}
					else if(hasGreen) {
						renderer.material.color = Color.green;
						colorCount = 2;
						break;
					}
					else if(hasBlue) {
						renderer.material.color = Color.blue;
						colorCount = 3;
						break;
					}
					else
						break;
				// if player is currently red
				case 1: if(hasGreen) {
						renderer.material.color = Color.green;
						colorCount = 2;
						break;
					}
					else if(hasBlue) {
						renderer.material.color = Color.blue;
						colorCount = 3;
						break;
					}
					else {
						renderer.material.color = Color.white;
						colorCount = 0;
						break;
					}
				// if player is currently green
				case 2: if(hasBlue) {
						renderer.material.color = Color.blue;
						colorCount = 3;
						break;
					}
					else {
						renderer.material.color = Color.white;
						colorCount = 0;
						break;
					}
				// if player is currently blue
				case 3: renderer.material.color = Color.white;
					colorCount = 0;
					break;
			}
		}
	}

	void FixedUpdate() {

	}

	void OnCollisionEnter(Collision collision) {
		Debug.Log("Shit, bro.");
		
	}
  
  /*
   * Called by paint when the player picks it up.
   */
  public void PickUp(Color color) {
    print("goodness me!");
    if(color == Color.green) {
      hasGreen = true;
    }
    if(color == Color.blue) {
      hasBlue = true;
    }
    if(color == Color.red) {
      hasRed = true;
    }
    colorShooting = color;
  }
}
