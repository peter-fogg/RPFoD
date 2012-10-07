using UnityEngine;
using System.Collections;

public class Paint : MonoBehaviour {
  
  public Color color;
  
  // Use this for initialization
  void Start () {
	
  }
	
  // Update is called once per frame
  void Update () {
	
  }
  
  /*
   * If a player walks over us, give them paint.
   */
  public void OnTriggerEnter(Collider other) {
    Player player = other.gameObject.GetComponent<Player>();
    if(player) {
      player.colorShooting = color;
      Destroy(gameObject);
    }
  }
  
  public static GameObject MakePaint(Vector3 position, Color color) {
    GameObject paint = GameObject.CreatePrimitive(PrimitiveType.Cube);
    paint.transform.position = position;
    paint.transform.localScale = new Vector3(.25f, .25f, .25f);
    paint.renderer.material.color = color;
    Paint paintScript = paint.AddComponent<Paint>();
    paintScript.color = color;
    return paint;
  }
}
