using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteCaps : MonoBehaviour {

	public int xMax,xMin, yMax,yMin;
	public GameObject whiteCapPrefab;
	// Use this for initialization
	void Start () {
		spawnWhiteCaps ();
	}
	void spawnWhiteCaps(){
		for(int x = xMax; x>xMin; x--){
			for(int y = yMax; y>yMin; y--){
				Instantiate(whiteCapPrefab, new Vector3(Random.Range(x, x+0.5f), Random.Range(y,y+0.5f), 0), Quaternion.identity);
			}
		}
	}
}
