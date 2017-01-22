﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tobii.EyeTracking;
using UnityEngine.SceneManagement;

public class PIPCameraFrame : MonoBehaviour {
	//public GameObject PIPImageObj;
    RawImage rawImage;

    bool isGazingOnTheFrame;
    float speedForFading = .25f;

    string currentUserName;
    Text playerInfoText;

    bool isProfileNameLoaded = false;

    public Collider2D videoFrameFadeoutTriggerCollider;
    public Collider2D aimingPointCollider;
    WebCamTexture webcamTexture;
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Use this for initialization
    void Start () {
       
       rawImage = gameObject.GetComponent<RawImage>();

	   webcamTexture = new WebCamTexture ();
        


		rawImage.texture = webcamTexture;
		rawImage.uvRect = new Rect (0.65f, 0.37f, -0.17f, 0.13f);
		rawImage.material.mainTexture = webcamTexture;

   //     rawImage.CrossFadeAlpha(0.5f, 5f, false);



		webcamTexture.Play ();
        
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.R))
        {

            while (webcamTexture != null && webcamTexture.isPlaying)
            {
                Debug.Log("is still playing");
                webcamTexture.Stop();
                webcamTexture = null;
                break;
            }

            SceneManager.LoadScene(0);
        }

        LoadProfileNameWhenTheTrackerIsReady();
        videoFrameFadeContral();
        
	}

    void videoFrameFadeContral() {
        if (videoFrameFadeoutTriggerCollider.IsTouching(aimingPointCollider))
        {
            Debug.Log("Touching!!");

            rawImage.CrossFadeAlpha(0.05f, speedForFading, false);
        }
        else
        {
            Debug.Log("not touching!");

            rawImage.CrossFadeAlpha(1f, speedForFading, false);

        }
    }


    void LoadProfileNameWhenTheTrackerIsReady()
    {



        if (!isProfileNameLoaded)
        {

            playerInfoText = GameObject.Find("PlayerInfoText").GetComponent<Text>();


            currentUserName = EyeTrackingHost.GetInstance().UserProfileName.ToString();



            playerInfoText.text = "Player: " + currentUserName;

            if (currentUserName != "INVALID")
                isProfileNameLoaded = true;

        }

    }




  


}
