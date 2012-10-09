using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
  
  public static GameObject player;
  
  // Use this for initialization
  void Start () {
    // Create the player and stuff
    Robot.MakeRobot(new Vector3(3.0f, .25f, 0f), Color.green, 3, 10, 1, new Vector3(0, 0, 0.5f));
    Paint.MakePaint(new Vector3(3.0f, .25f, 1.0f), Color.green);
    player = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    player.transform.position = new Vector3(0, 0.25F, 0);
    player.transform.localScale = new Vector3(0.5F, 0.5F, 0.5F);
    player.AddComponent("Player");
    player.renderer.material.color = Color.white;
    player.name = "Player";

    GameObject wall = GameObject.Find("Cube");
    while(wall != null) {
	wall.name = "Wall";
	wall.AddComponent("WallBlock");
	wall = GameObject.Find("Cube");
    }
  }
  
  // Update is called once per frame
  void Update () {
    
  }
  
  /*
   * For checking if a particular position is occupied. Returns true
   * if it is occupied, false if not.
   */
  public static bool CheckPosition(Vector3 position) {
    Collider[] objects = Physics.OverlapSphere(position, .1f);
    // make sure the objects aren't player or paint
    foreach(Collider coll in objects) {
      if(!coll.gameObject.GetComponent<Player>() &&
	 !coll.gameObject.GetComponent<Paint>())
	return true;
    }
    return false;
  }

  public static bool CheckPlayerPosition(Vector3 position) {
    Collider[] objects = Physics.OverlapSphere(position, .1f);
    // check whether the objects are walls
    foreach(Collider coll in objects) {
      if(coll.gameObject.GetComponent<WallBlock>())
	return true;
    }
    return false;
  }

}
