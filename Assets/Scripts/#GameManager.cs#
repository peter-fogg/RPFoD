using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
  
	public static GameObject player;
	private Quaternion camRot;

	// Use this for initialization
	void Start () {
		// Create the player and stuff
		Robot.MakeRobot(new Vector3(3.0f, .25f, 0f), Color.green, 3, 10, 1, new Vector3(0, 0, 0.5f));
		Paint.MakePaint(new Vector3(2.0f, .25f, 1.0f), Color.green);
		Paint.MakePaint(new Vector3(-1.0f, .25f, -1.0f), Color.red);
		Paint.MakePaint(new Vector3(0.0f, .25f, 2.0f), Color.blue);
		player = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		player.transform.position = new Vector3(-9.5f, 0.25F, -8.5f);
		player.transform.localScale = new Vector3(0.5F, 0.5F, 0.5F);
		player.AddComponent("Player");
		player.renderer.material.color = Color.white;
		player.name = "Player";

		// Anything named "Cube" is now named "Wall"
		GameObject wall = GameObject.Find("Cube");
		while(wall != null) {
			wall.name = "Wall";
			wall.AddComponent("WallBlock");
			wall = GameObject.Find("Cube");
		}

		camRot = Camera.main.transform.rotation;
	}
  
	// Update is called once per frame
	void Update () {
		Camera.main.transform.rotation = camRot;
	}
  
	/*
	 * For checking if a particular position is occupied. Returns true
	 * if it is occupied, false if not.
	 */
	public static bool CheckPosition(Vector3 position) {
		Collider[] objects = Physics.OverlapSphere(position, .1f);
		// make sure the objects aren't player or paint
		foreach(Collider coll in objects) {
			if(coll.gameObject.GetComponent<Player>()) {
				GameManager.player.GetComponent<Player>().health = 0;
				print("Haha! I'll crush you!");
			}
			else if(!coll.gameObject.GetComponent<Paint>() &&
				!coll.gameObject.GetComponent<Projectile>() &&
				!coll.gameObject.GetComponent<Bullet>())
				return true;
		}
		return false;
	}

	public static bool CheckPlayerPosition(Vector3 position) {
		Collider[] objects = Physics.OverlapSphere(position, .1f);
		// check whether the objects are walls
		foreach(Collider coll in objects) {
			if(coll.gameObject.GetComponent<WallBlock>() ||
			   coll.gameObject.GetComponent<Robot>())
				return true;
		}
		return false;
	}

	public void OnGUI() {
		Player p = player.GetComponent<Player>();
		GUI.Box(new Rect(10, 10, 100, 25), "Health: " + p.health);
		GUI.Box(new Rect(10, 50, 150, 25), "Color Shooting: " +
			((p.colorShooting == Color.blue) ? "Blue" :
			(p.colorShooting == Color.red) ? "Red" :
			(p.colorShooting == Color.green) ? "Green" :
			 "None"));
	}
}
