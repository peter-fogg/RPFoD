using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

  // Use this for initialization
  void Start () {
    Robot.MakeRobot(new Vector3(3.0f, .25f, 0f), Color.red, 3, 10, 1, new Vector3(0, 0, 0.5f));
    GameObject player = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    player.transform.position = new Vector3(0, 0.25F, 0);
    player.transform.localScale = new Vector3(0.5F, 0.5F, 0.5F);
  }
  
  // Update is called once per frame
  void Update () {
    
  }
  
  /*
   * For checking if a particular position is occupied. Returns true
   * if it is occupied, false if not.
   */
  public static bool CheckPosition(Vector3 position) {
    return Physics.OverlapSphere(position, .1f).Length != 0;
  }
}
