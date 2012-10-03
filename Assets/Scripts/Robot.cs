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
    if(target != null) {
      
    }
    else {
      transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    
  }
  
  public void OnTriggerEnter(Collider other) {
    
  }
  
  public static GameObject MakeRobot(Vector3 position, Color colorVisible,
			      int damage, int health, float speed) {
    GameObject robot = GameObject.CreatePrimitive(PrimitiveType.Cube);
    robot.transform.position = position;
    robot.transform.localScale = new Vector3(.5f, .5f, .5f);
    robot.renderer.material.color = colorVisible;
    Robot robotScript = robot.AddComponent<Robot>();
    robotScript.damage = damage;
    robotScript.health = health;
    robotScript.speed = speed;
    robotScript.speed = speed;
    robotScript.colorVisible = colorVisible;
    return robot;
  }
}
