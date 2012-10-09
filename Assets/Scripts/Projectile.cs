// Projectile SuperClass

using UnityEngine;
using System.Collections;

/*r = x, b = z  */

public class Projectile : MonoBehaviour
{
	public Vector3 dir; // direction it's headed
	public Color colorPainted;

	void Update()
	{
		transform.Translate(dir*Time.time);
	}
	
	static GameObject MakeProj(Vector3 position, Vector3 dir, Color col){
		GameObject proj = GameObject.CreatePrimitive(PrimitiveType.Cube);
		proj = new GameObject("Projectile");
		proj.transform.localScale = new Vector3(.5f, .5f, .5f);
		proj.renderer.material.color = col;
		Projectile projScript = proj.AddComponent<Projectile>();
		projScript.colorPainted = col;
		projScript.dir = dir;
		return proj;
	}
}
