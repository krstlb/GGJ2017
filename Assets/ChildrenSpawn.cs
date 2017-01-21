using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildrenSpawn : MonoBehaviour {

	public GameObject childPrefab;
	public int xMin,xMax,yMin,yMax;




	// Use this for initialization
	void Start () {
		InvokeRepeating (
			"spawnChild", 1f,2f
		);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void spawnChild(){
		Instantiate(childPrefab, new Vector3(Random.Range(xMin, xMax), Random.Range(yMin,yMax), 0), Quaternion.identity);
	}
}
