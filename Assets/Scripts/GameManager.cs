using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

  // Use this for initialization
  void Start () {
    Robot.MakeRobot(new Vector3(0f, .25f, 0f), Color.red, 3, 10, 1);
    // Create the player and stuff
    GameObject player = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    player.transform.position = new Vector3(0, 0.25F, 0);
    player.transform.localScale = new Vector3(0.5F, 0.5F, 0.5F);
    player.AddComponent("Player");
  }
  
  // Update is called once per frame
  void Update () {
    
  }
}
