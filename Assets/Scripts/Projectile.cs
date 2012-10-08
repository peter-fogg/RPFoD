// Projectile SuperClass

using UnityEngine;
using System.Collections;

/*r = x, b = z  */
/*
public class Projectile : MonoBehaviour
{
	public int damage; // damage a bullet does
	public int range; // range it goes before performing end action
	public int speed; // speed it moves
	public int dir; // direction it's headed

	void Update()
	{
		switch(dir)
		{
			case(NORTH):
				Transform.translate(transform.position.forward*speed);
				break;
			case(EAST):
				Transform.translate(transform.position.right*speed);
				break;
			case(SOUTH):
				Transform.translate(-1*(transform.position.forward)*speed):
				break;
			case(WEST):
				Transform.translate(-1*(transform.position.right)*speed);
				break;
		}
	}
	
	static GameObject Projectile(Vector3 position, int damage, int range, int speed, int dir){
		GameObject proj = GameObject.CreatePrimitive(PrimitiveType.Cube)
		proj = new GameObject("Projectile");
		proj.AddComponent("Rigidbody");
		proj.AddComponent("Projectile.cs);
	}
}*/
