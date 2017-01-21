using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PIPCameraFrame : MonoBehaviour {
	public RawImage rawImage;

	// Use this for initialization
	void Start () {
		WebCamTexture webcamTexture = new WebCamTexture ();
		rawImage.texture = webcamTexture;
		rawImage.uvRect = new Rect (0.65f, 0.37f, -0.17f, 0.13f);
		rawImage.material.mainTexture = webcamTexture;
		webcamTexture.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
