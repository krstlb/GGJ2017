using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {
	public Button yourButton;

	// Use this for initialization
	void Start () {
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(Play);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Play() {
		SceneManager. LoadScene("Scenes/GGJ2017");
	}
}
