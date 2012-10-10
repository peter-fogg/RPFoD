using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public bool hasRed;
	public bool hasGreen;
	public bool hasBlue;
	public Color colorPainted; // the color that the player is currently painted
	public Color colorShooting; // the color that the player is currently shooting

        public int health;
	public int dir;
  
	public static Vector3 forward = new Vector3(0, 0, 0.5F);
	public static Vector3 backward = new Vector3(0, 0, -0.5F);
	public static Vector3 right = new Vector3(-0.5F, 0, 0);
	public static Vector3 left = new Vector3(0.5F, 0, 0);

	private int colorCount = 0;

	// Use this for initialization
	void Start () {
		health = 15;
	}
	
	// Update is called once per frame
	void Update () {
		if(health == 0) {
			Time.timeScale = 0;
		}
		if(Input.GetKeyDown("w") /*&& transform.position.z < 4.5F*/) {
			if(!GameManager.CheckPlayerPosition(transform.position + forward)) {
				transform.rotation = new Quaternion(0, 0, 0, 0);
				transform.Translate(forward);
				Camera.main.transform.Translate(new Vector3(0, 0.5F, 0));
				dir = 0;
			}
		}	
		if(Input.GetKeyDown("a") /*&& transform.position.x > -4.5F*/) {
			if(!GameManager.CheckPlayerPosition(transform.position + right)) {
				transform.rotation = new Quaternion(0, -90F, 0, 0);
				transform.Translate(left);
				Camera.main.transform.Translate(new Vector3(-0.5F, 0, 0));
				dir = 3;
			}
		}
		if(Input.GetKeyDown("d") /*&& transform.position.x < 4.5F*/) {
			if(!GameManager.CheckPlayerPosition(transform.position + left)) {
				transform.rotation = new Quaternion(0, 90F, 0, 0);
				transform.Translate(right);
				Camera.main.transform.Translate(new Vector3(0.5F, 0, 0));
				dir = 1;
			}
		}
		if(Input.GetKeyDown("s") /*&& transform.position.z > -4.5F*/) {
			if(!GameManager.CheckPlayerPosition(transform.position + backward)) {
				transform.rotation = new Quaternion(0, 180F, 0, 0);
				transform.Translate(forward);
				Camera.main.transform.Translate(new Vector3(0, -0.5F, 0));
				dir = 2;
			}
		}
		
		if(Input.GetKeyDown("q")) {
			// super-janky code for cycling through available colors
			switch(colorCount) {
				// if player is currently white
				case 0: if(hasRed) {
					renderer.material.color = Color.red;
					colorPainted = Color.red;
					colorCount = 1;
					break;
				}
				else if(hasGreen) {
					renderer.material.color = Color.green;
					colorPainted = Color.green;
					colorCount = 2;
					break;
				}
				else if(hasBlue) {
					renderer.material.color = Color.blue;
					colorPainted = Color.blue;
					colorCount = 3;
					break;
				}
				else
					break;
				// if player is currently red
				case 1: if(hasGreen) {
					renderer.material.color = Color.green;
					colorPainted = Color.green;
					colorCount = 2;
					break;
				}
				else if(hasBlue) {
					renderer.material.color = Color.blue;
					colorPainted = Color.blue;
					colorCount = 3;
					break;
				}
				else {
					renderer.material.color = Color.white;
					colorPainted = Color.white;
					colorCount = 0;
					break;
				}
				// if player is currently green
				case 2: if(hasBlue) {
					renderer.material.color = Color.blue;
					colorPainted = Color.blue;
					colorCount = 3;
					break;
				}
				else {
					renderer.material.color = Color.white;
					colorPainted = Color.white;
					colorCount = 0;
					break;
				}
				// if player is currently blue
				case 3: renderer.material.color = Color.white;
					colorPainted = Color.white;
					colorCount = 0;
					break;
			}
		}
		if(Input.GetKeyDown("e")) { // super-jank for switching shooting color
			print("FUCK " + colorCount);
			if(hasRed && hasGreen && hasBlue) {
				if(colorShooting == Color.red) {
					colorShooting = Color.green;
				}
				else if(colorShooting == Color.green) {
					colorShooting = Color.blue;
				}
				else if(colorShooting == Color.blue) {
					colorShooting = Color.red;
				}
			}
			else if(hasRed && hasBlue) {
				if(colorShooting == Color.red) {
					colorShooting = Color.blue;
				}
				else {
					colorShooting = Color.red;
				}
			}
			else if(hasRed && hasGreen) {
				if(colorShooting == Color.red) {
					colorShooting = Color.green;
				}
				else {
					colorShooting = Color.red;
				}
			}
			else if(hasGreen && hasBlue) {
				if(colorShooting == Color.blue) {
					colorShooting = Color.green;
				}
				else {
					colorShooting = Color.blue;
				}
			}
		}
	
		if(Input.GetKeyDown(KeyCode.Space)) {
		// fires projectiles

			Projectile.MakeProj(transform.position, dir, colorShooting);
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
		if(colorCount == 0) {
			colorShooting = color;
		}
		if(color == Color.green) {
			if(!hasGreen) {
				colorCount++;
			}
			hasGreen = true;
		}
		if(color == Color.blue) {
			if(!hasBlue) {
				colorCount++;
			}
			hasBlue = true;
		}
		if(color == Color.red) {
			if(!hasRed) {
				colorCount++;
			}
			hasRed = true;
		}
	}
}
