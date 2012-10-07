using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour {
  
  public int health;
  public float speed;
  public int damage;
  public Color colorPainted;
  public Color colorVisible;
  public GameObject target;
  public float lastMoved;
  public Vector3 direction;
  
  void Start () {
    lastMoved = Time.time;
  }
  
  void Update () {
    if(health <= 0) {
      Destroy(gameObject);
    }
    if(target != null) {
      
    }
    else if(Time.time > lastMoved + speed) {
      // if we hit a wall, change direction
      if(GameManager.CheckPosition(transform.position + direction)) {
	direction *= -1.0f;
      }
      transform.Translate(direction);
      lastMoved = Time.time;
    }
    
  }
  
  public void OnTriggerEnter(Collider other) {
    
  }
  
  public static GameObject MakeRobot(Vector3 position, Color colorVisible,
				     int damage, int health, float speed,
				     Vector3 direction) {
    GameObject robot = GameObject.CreatePrimitive(PrimitiveType.Cube);
    robot.transform.position = position;
    robot.transform.localScale = new Vector3(.5f, .5f, .5f);
    robot.name = "Robot";
    robot.renderer.material.color = colorVisible;
    Robot robotScript = robot.AddComponent<Robot>();
    robotScript.damage = damage;
    robotScript.health = health;
    robotScript.speed = speed;
    robotScript.speed = speed;
    robotScript.colorVisible = colorVisible;
    robotScript.direction = direction;
    return robot;
  }
}
