using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	public int damage;
	public Vector3 direction;
	public float speed;
	
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

	public static GameObject MakeBullet(Vector3 position, Vector3 direction, int damage, float speed) {
		GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Cube);
		bullet.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
		bullet.transform.position = position;
		bullet.renderer.material.color = Color.black;
		bullet.AddComponent<Rigidbody>();
		Bullet bulletScript = bullet.AddComponent<Bullet>();
		bulletScript.direction = direction;
		bulletScript.damage = damage;
		bulletScript.speed = speed;
		return bullet;
	}

	public void OnTriggerEnter(Collider other) {
		Player player = other.gameObject.GetComponent<Player>();
		print("blasdfsadf");
		if(player != null) {
			print("Dadgummit!");
			player.health -= damage;
			Destroy(gameObject);
		}
	}
}
