// Projectile SuperClass

using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
	public Vector3 dir; // direction it's headed
	public Color colorPainted;

	void Update()
	{
		transform.Translate(dir*Time.deltaTime*80);
	}
	
	public static GameObject MakeProj(Vector3 position, Vector3 dir, Color col){
		GameObject proj = GameObject.CreatePrimitive(PrimitiveType.Cube);
		proj.transform.localScale = new Vector3(.1f, .1f, .1f);
		proj.renderer.material.color = col;
		proj.transform.position = position;
		Projectile projScript = proj.AddComponent<Projectile>();
		projScript.colorPainted = col;
		projScript.dir = dir;
		return proj;
	}
}
