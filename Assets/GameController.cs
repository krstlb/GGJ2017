using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	private SoundController soundController;

	// Use this for initialization
	void Start () {
		soundController = GameObject.FindGameObjectWithTag ("SoundController").GetComponent<SoundController> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
