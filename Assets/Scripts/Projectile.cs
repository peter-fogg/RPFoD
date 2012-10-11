// Projectile SuperClass

using UnityEngine;
using System.Collections;

/*z=b x=r*/

public class Projectile : MonoBehaviour
{
	public int dir; // direction it's headed
	public Color colorPainted;
	public Vector3 face;
	public GameObject cameFrom;
	public float speed;
	
	void Start() {
		speed = 0.25f;
	}
	
	void Update()
	{
		switch(dir)
		{
			case 0:
				transform.Translate(Vector3.forward * speed);
				break;
			case 1:
				transform.Translate(Vector3.right * speed);
				break;
			case 2:
				transform.Translate(-(Vector3.forward * speed));
				break;
			case 3:
				transform.Translate(-(Vector3.right * speed));
				break;
		}
		Destroy(gameObject, 1);
	}

	
	
	public static GameObject MakeProj(Vector3 position, int dir, Color col, GameObject cameFrom){
		GameObject proj = GameObject.CreatePrimitive(PrimitiveType.Cube);
		proj.transform.localScale = new Vector3(.0625f, .0625f, .0625f);
		proj.renderer.material.color = col;
		proj.transform.position = position;
		proj.name = "Projectile";
		Projectile projScript = proj.AddComponent<Projectile>();
		projScript.colorPainted = col;
		projScript.dir = dir;
		projScript.cameFrom = cameFrom;
		proj.AddComponent<Rigidbody>();
		proj.rigidbody.isKinematic = false;
		proj.rigidbody.useGravity = false;
		proj.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
		proj.rigidbody.collider.isTrigger = true;
		proj.rigidbody.collider.enabled = true;

		switch(dir)
		{
			case(0):	projScript.face = Vector3.forward;break;
			case(1):	projScript.face = Vector3.right;break;
			case(2):	projScript.face = -(Vector3.forward);break;
			case(3):	projScript.face = -(Vector3.right);break;
		}
	
		return proj;
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject == cameFrom) {
			return;
		}
		Robot robot = other.gameObject.GetComponent<Robot>();
		if(robot != null) {
			robot.SetColorPainted(colorPainted);
		}
		else {
			WallBlock block = other.gameObject.GetComponent<WallBlock>();
			if(block != null) {
				block.SetColorPainted(colorPainted);
			}
		}
		Destroy(gameObject);
	}
}
