using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	public int damage;
	public Vector3 direction;
	public float speed;
	public GameObject cameFrom;
	
	// Use this for initialization
	void Start () {
		collider.isTrigger = true;
		collider.enabled = true;
		rigidbody.isKinematic = false;
		rigidbody.useGravity = false;
		rigidbody.constraints = RigidbodyConstraints.FreezeAll;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(direction*speed);
	}

	public static GameObject MakeBullet(Vector3 position, Vector3 direction, int damage,
					    float speed, GameObject cameFrom) {
		GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Cube);
		bullet.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
		bullet.transform.position = position;
		bullet.renderer.material.color = Color.black;
		bullet.AddComponent<Rigidbody>();
		Bullet bulletScript = bullet.AddComponent<Bullet>();
		bulletScript.direction = direction;
		bulletScript.damage = damage;
		bulletScript.speed = speed;
		bulletScript.cameFrom = cameFrom;
		return bullet;
	}

	public void OnTriggerEnter(Collider other) {
		if(other.gameObject == cameFrom) {
			return;
		}
		Player player = other.gameObject.GetComponent<Player>();
		if(player != null) {
			player.health -= damage;
			Destroy(gameObject);
			return;
		}
		Robot robot = other.gameObject.GetComponent<Robot>();
		if(robot != null) {
			robot.health -= damage;
			Destroy(gameObject);
			return;
		}
	}
}
