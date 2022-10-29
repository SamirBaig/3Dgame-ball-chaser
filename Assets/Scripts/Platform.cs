using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	void OnTriggerEnter(Collider collider) { 
		if (collider.gameObject.tag == "Player") { //player = ball script
			Invoke ("FallDown", 0.6f); // 0.6 seconds wait till platform falls
		}
	}
	//this will fall platform
	private void FallDown() {
		this.GetComponentInParent<Rigidbody>().isKinematic = false; 
		Destroy (this.transform.parent.gameObject, 2f); //0.6 seconds to fall and 2 seconds to destroy fallen platform
	}
}
