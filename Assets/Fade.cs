using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

	private SpriteRenderer spriteRenderer;
	public float fade;
	// Use this for initialization
	void Start () {
		spriteRenderer = gameObject.transform.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		Color tempColor;
		tempColor = spriteRenderer.color;
		tempColor.a -= fade * Time.deltaTime;
		spriteRenderer.color = tempColor;

		if (tempColor.a <= 0) {
			Destroy (gameObject);
		}
	}
}
