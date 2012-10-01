using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour {
  
  public int health;
  public float speed;
  public int damage;
  public Color colorPainted;
  public Color colorVisible;
  public GameObject target;
  
  void Start () {
    
  }
  
  void Update () {
    if(health <= 0) {
      Destroy(gameObject);
    }
    
  }
  
  static GameObject MakeRobot(Vector3 position, Color colorVisible,
			      int damage, int health, float speed) {
    GameObject robot = GameObject.CreatePrimitive(PrimitiveType.Cube);
    robot.transform.position = position;
    Robot robotScript = robot.AddComponent<Robot>();
    robotScript.damage = damage;
    robotScript.health = health;
    robotScript.speed = speed;
    robotScript.speed = speed;
    robotScript.colorVisible = colorVisible;
    return robot;
  }
}
