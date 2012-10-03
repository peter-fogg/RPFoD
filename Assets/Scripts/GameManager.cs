using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

  // Use this for initialization
  void Start () {
    Robot.MakeRobot(new Vector3(0f, .25f, 0f), Color.red, 3, 10, 1);
  }
  
  // Update is called once per frame
  void Update () {
    
  }
}
