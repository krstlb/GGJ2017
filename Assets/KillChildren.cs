using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillChildren : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "DeadZone") {
			Destroy (this.gameObject);
		} else if (other.tag == "SafeZone")
			Destroy (this.gameObject);
	}

}
