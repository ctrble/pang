using UnityEngine;
using System.Collections;

public class Paddle_Charger : MonoBehaviour {

	//assigned in inspector
	//public PhysicsMaterial2D physicsMaterial2D;

	public bool playerOneCharging;
	public bool playerTwoCharging;

	public bool playerOneSlowing;
	public bool playerTwoSlowing;

	//get inputs
	private Input_Controller inputController;


	void OnEnable () {

		//get inputs
		if (inputController == null) {

			inputController = GetComponent<Input_Controller> ();
		}
			
		playerOneCharging = false;
		playerTwoCharging = false;

		playerOneSlowing = false;
		playerTwoSlowing = false;

		//physicsMaterial2D.bounciness = 1;
		//Debug.Log (physicsMaterial2D.bounciness);
	}

	void Update () {

		if (inputController.charge) {

			//player 1
			if (gameObject.name == "Player 1") {

				playerOneCharging = true;
				//Debug.Log ("p1 charging");
			} 

			//player 1
			if (gameObject.name == "Player 2") {

				playerTwoCharging = true;
				//Debug.Log ("p2 charging");
			}
		} else if (inputController.charge == false) {
		
			playerOneCharging = false;
			playerTwoCharging = false;
		}

		if (inputController.slow) {

			//player 1
			if (gameObject.name == "Player 1") {

				playerOneSlowing = true;
				//Debug.Log ("p1 charging");
			} 

			//player 1
			if (gameObject.name == "Player 2") {

				playerTwoSlowing = true;
				//Debug.Log ("p2 charging");
			}
		} else if (inputController.slow == false) {

			playerOneSlowing = false;
			playerTwoSlowing = false;
		}
	}

}
