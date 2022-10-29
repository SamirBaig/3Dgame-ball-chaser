using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	// Initialize variables.
	private Rigidbody rb;
	private bool isMovingRight = false;
	private bool hasPlayerStarted = false;

	[SerializeField]
	float speed = 4f;

	[HideInInspector]
	public bool canMove = true;

	[SerializeField] //to searalize a private object
	GameObject particle;

	[SerializeField]
	GameObject gems;

	[SerializeField] //score variable
	private Text scoreText;
	private int score = 0;


	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && canMove == true) {

			// If the game hasen't started yet.
			if (hasPlayerStarted == false) {
				hasPlayerStarted = true;   //starting movement of ball
				StartCoroutine (ShowGems (2.5f)); //showing gems //f = float variable
			}
				
			ChangeBoolean ();
			ChangeDirection ();
		}
		//transform.position = vector3.down == true
		if (Physics.Raycast (this.transform.position, Vector3.down * 2) == false) { 
			FallDown ();
		}
	}



	// Hide the gems for the first 2.5 seconds
	IEnumerator ShowGems (float count) {
		yield return new WaitForSeconds (count);

		// Checks if player hasn't fallen off before showing gems.
		if (canMove == true) {
			gems.SetActive (true);
		}
	}
		

	// Control player direction.
	private void ChangeBoolean() {
		isMovingRight = !isMovingRight;  //changing true to false directions of ball
	}
	private void ChangeDirection() { //will change direction while watching ismovingright
		if (isMovingRight == true) {
			rb.velocity = new Vector3 (speed, 0f, 0f);
		} 
		else {
			rb.velocity = new Vector3 (0f,0f,speed);
		}
	}


	// When the player falls off the platform.
	private void FallDown() {
		canMove = false;
		rb.velocity = new Vector3 (0f,-4f,0f);

		// Retutn to main menu.
		StartCoroutine (ReturnToMainMenu (2.8f));
	}
	// Return to main menu.
	IEnumerator ReturnToMainMenu (float count) {
		yield return new WaitForSeconds (count);
		Application.LoadLevel(0);
	}


	// When the player hits a gem.
	void OnTriggerEnter(Collider other) {  //this runs when two objects collides
		if (other.gameObject.tag == "Gem") {
			// other = gem

			// Remove the gem.
			Destroy (other.gameObject);
		
			// Create the particle effect.
			GameObject _particle = Instantiate (particle) as GameObject; //creating
			_particle.transform.position = this.transform.position; // set position
			Destroy (_particle, 1f); //destroy particle effect

			// Update the score.
			score++;
			scoreText.text = "Score: " + score.ToString();
		}
	}
}
