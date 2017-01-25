﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour {
	public Button yourButton;

	// Use this for initialization
	void Start () {
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(Quit);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Quit() {
		Application.Quit ();
	}
}