using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour {

	//how fast
	public int speed;

	//get inputs
	private Input_Controller inputController;


	void OnEnable () {

		//get inputs
		if (inputController == null) {
		
			inputController = GetComponent<Input_Controller> ();
		}

		//set speed
		speed = 250;
	}
	
	void Update () {

		//move me
		ApplyMovement ();
	}

	void ApplyMovement () {

		//clockwise
		if (inputController.positive && inputController.negative == false) {
			
			transform.RotateAround(Vector3.zero, Vector3.forward, speed * Time.deltaTime);
		}

		//counterclockwise
		if (inputController.negative && inputController.positive == false) {
			
			transform.RotateAround(Vector3.zero, Vector3.back, speed * Time.deltaTime);
		}


	}
}
