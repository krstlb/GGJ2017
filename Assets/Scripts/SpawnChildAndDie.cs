using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChildAndDie : MonoBehaviour {
	public GameObject child;
	public AudioSource audioSource;
	AudioClip audioClipSpawn;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		StartCoroutine (SpawnAndDie ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator SpawnAndDie() {
		yield return new WaitForSeconds(2f);
		Instantiate (child, this.gameObject.transform.position, Quaternion.identity);
		audioClipSpawn = (AudioClip)Resources.Load ("Sound/spawnSplash");
		audioSource.clip = audioClipSpawn;
		audioSource.Stop ();
		audioSource.Play ();
		Destroy(gameObject);
	}
}
