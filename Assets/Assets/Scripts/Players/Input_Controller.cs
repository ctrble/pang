using UnityEngine;
using System.Collections;

public class Input_Controller : MonoBehaviour {

	//directional bool
	public bool positive;
	public bool negative;
	public bool charge;
	public bool slow;

	//buttons
	public string positiveButton;
	public string negativeButton;
	public string chargeButton1;
	public string chargeButton2;
	
	void OnEnable () {

		//set player 1 or player 2
		SetPlayer ();

		charge = false;
		slow = false;
	}
	
	void Update () {

		//input
		InputControls ();		
	}
	
	void SetPlayer () {

		//player 1
		if (gameObject.name == "Player 1") {
			
			positiveButton = "w";
			negativeButton = "s";
			chargeButton1 = "a";
			chargeButton2 = "d";
		}

		//player2
		if (gameObject.name == "Player 2") {
			
			positiveButton = "up";
			negativeButton = "down";
			chargeButton1 = "left";
			chargeButton2 = "right";
		}
	}
	
	void InputControls () {

		//positive
		if (Input.GetKey(positiveButton)) {
			
			positive = true;
		} else {
			
			positive = false;
		}

		//negative
		if (Input.GetKey(negativeButton)) {
			
			negative = true;
		} else {
			
			negative = false;
		}

		//charge
		if (Input.GetKey(chargeButton2)) {

			charge = true;
		} else {

			charge = false;
		}

		//slow
		if (Input.GetKey(chargeButton1)) {

			slow = true;
		} else {

			slow = false;
		}
	}

}
