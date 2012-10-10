using UnityEngine;
using System.Collections;

public class Paint : MonoBehaviour {
  
	public Color color;
  
	// Use this for initialization
	void Start () {
		collider.isTrigger = true;
		// gameObject.AddComponent<Rigidbody>();
		// rigidbody.useGravity = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(transform.position, GameManager.player.transform.position) < .1) {
			GameManager.player.GetComponent<Player>().PickUp(color);
			Destroy(gameObject);
		}
	}
  
	/*
	 * If a player walks over us, give them paint.
	 */
	void OnTriggerEnter(Collider other) {
		Player player = other.gameObject.GetComponent<Player>();
		if(player) {
			player.colorShooting = color;
			Destroy(gameObject);
		}
	}
  
	public static GameObject MakePaint(Vector3 position, Color color) {
		GameObject paint = GameObject.CreatePrimitive(PrimitiveType.Cube);
		paint.transform.position = position;
		paint.transform.localScale = new Vector3(.25f, .25f, .25f);
		paint.renderer.material.color = color;
		paint.collider.enabled = true;
		paint.name = "Paint";
		Paint paintScript = paint.AddComponent<Paint>();
		paintScript.color = color;
		return paint;
	}
}
