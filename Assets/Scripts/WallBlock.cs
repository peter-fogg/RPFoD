using UnityEngine;
using System.Collections;

public class WallBlock : MonoBehaviour {
  
	public Color currentColor;
  
	// Use this for initialization
	void Start () {
		gameObject.renderer.material.color = currentColor;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void SetColorPainted(Color color) {
		currentColor = color;
		renderer.material.color = color;
	}
}
