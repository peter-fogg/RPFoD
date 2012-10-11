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
			Bullet.MakeBullet(transform.position, direction, damage, 1.0f);
		}
		else if(Physics.Raycast(transform.position, direction, out hit)) {
		       Robot robot = hit.collider.gameObject.GetComponent<Robot>();
		       if(robot != null && robot.colorPainted == colorVisible && Vector3.Distance(transform.position, robot.transform.position) < 5.0f) {
			       robot.health -= damage;
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
		robot.renderer.material.color = colorVisible;
		robot.AddComponent<Rigidbody>();
		Robot robotScript = robot.AddComponent<Robot>();
		robotScript.damage = damage;
		robotScript.health = health;
		robotScript.speed = speed;
		robotScript.speed = speed;
		robotScript.colorVisible = colorVisible;
		robotScript.direction = direction;
		return robot;
	}
}
