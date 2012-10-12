using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour {
  
	public int health;
	public float speed;
	public float fireRate;
	public int damage;
	public Color colorPainted;
	public Color colorVisible;
	public GameObject target;
	public float lastMoved;
	public float lastFired;
	public Vector3 direction;
	public GameObject colorIndicator; // a cube painted the color which we see
  
	void Start () {
		lastMoved = Time.time;
		lastFired = Time.time;
		fireRate = 1;
		rigidbody.isKinematic = false;
		rigidbody.useGravity = false;
		rigidbody.constraints = RigidbodyConstraints.FreezeAll;
	}
  
	void Update () {
		if(health <= 0) {
			Destroy(gameObject);
		}
		if(target != null) {
      
		}
		else if(Time.time > lastMoved + speed) {
			// if we hit a wall, change direction
			if(GameManager.CheckPosition(transform.position + direction)) {
				direction *= -1.0f;
			}
			transform.Translate(direction);
			lastMoved = Time.time;
		}
		if(Time.time > lastFired + fireRate) {
			Fire();
			lastFired = Time.time;
		}
	}

	public void Fire() {
		Player player = GameManager.player.GetComponent<Player>();
		RaycastHit hit;
		if(Physics.Raycast(transform.position, direction, out hit) &&
		   hit.collider.gameObject.GetComponent<Player>() == player &&
		   player.colorPainted == colorVisible &&
		   Vector3.Distance(transform.position, player.transform.position) < 5.0f) {
			Bullet.MakeBullet(transform.position, direction, damage, 1.0f, gameObject);
		}
		if(Physics.Raycast(transform.position, direction, out hit)) {
			Robot robot = hit.collider.gameObject.GetComponent<Robot>();
			if(robot != null && robot.colorPainted == colorVisible && Vector3.Distance(transform.position, robot.transform.position) < 5.0f) {
				Bullet.MakeBullet(transform.position, direction, damage, 1.0f, gameObject);
			}
		}
		if(Physics.Raycast(transform.position, direction, out hit)) {
			WallBlock block = hit.collider.gameObject.GetComponent<WallBlock>();
			if(block != null && block.currentColor == colorVisible &&
			   Vector3.Distance(transform.position, block.transform.position) < 5.0f) {
				Bullet.MakeBullet(transform.position, direction, damage, 1.0f, gameObject);
			}
		}
	}
  
	public void OnTriggerEnter(Collider other) {
		
	}
  
	public static GameObject MakeRobot(Vector3 position, Color colorVisible,
					   int damage, int health, float speed,
					   Vector3 direction) {
		GameObject robot = GameObject.CreatePrimitive(PrimitiveType.Cube);
		robot.transform.position = position;
		robot.transform.localScale = new Vector3(.5f, .5f, .5f);
		robot.name = "Robot";
		robot.AddComponent<Rigidbody>();
		GameObject colorIndicator = GameObject.CreatePrimitive(PrimitiveType.Cube);
		colorIndicator.renderer.material.color = colorVisible;
		colorIndicator.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
		colorIndicator.transform.position = position + new Vector3(0.0f, 0.5f, 0.0f);
		colorIndicator.transform.parent = robot.transform;
		Robot robotScript = robot.AddComponent<Robot>();
		robotScript.colorIndicator = colorIndicator;
		robotScript.damage = damage;
		robotScript.health = health;
		robotScript.speed = speed;
		robotScript.speed = speed;
		robotScript.colorVisible = colorVisible;
		robotScript.direction = direction;
		return robot;
	}

	public void SetColorPainted(Color color) {
		colorPainted = color;
		renderer.material.color = colorPainted;
	}
}
