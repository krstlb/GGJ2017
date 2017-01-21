using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColour : MonoBehaviour {
	SpriteRenderer spriteRenderer;
	public float rValue;
	public float gValue;
	public float bValue;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		rValue = Random.Range(0f, 255f);
		changeColor(rValue, gValue, bValue);
	}

	void changeColor(float r, float g, float b) {
		
		Color tempColor;
		tempColor = spriteRenderer.color;
		tempColor.r -= rValue * Time.deltaTime;
		tempColor.g -= gValue * Time.deltaTime;
		tempColor.b -= bValue * Time.deltaTime;
		spriteRenderer.color = tempColor;
	}
}
