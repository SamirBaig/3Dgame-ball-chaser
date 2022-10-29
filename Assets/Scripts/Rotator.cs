using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
	// it is used to rotate gems
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3(15,20,45) * Time.deltaTime); //to rotate the gems on same speed for all devices
	}
}
