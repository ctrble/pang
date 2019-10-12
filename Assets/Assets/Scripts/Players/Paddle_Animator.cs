using UnityEngine;
using System.Collections;

public class Paddle_Animator : MonoBehaviour {

	//the animator
	public Animator animator;

	//get input controller
	private Input_Controller inputController;

	void OnEnable () {

		//get the animator
		if (animator == null) {
			animator = GetComponent<Animator> ();
		}

		//get speed
		if (inputController == null) {

			inputController = GetComponentInParent<Input_Controller> ();
		}
	}

	void Update() {


		if (inputController.charge == true && inputController.slow == false) {

			Debug.Log ("charging");

			animator.SetBool ("speedup", true);
			animator.SetBool ("neutral", false);
			animator.SetBool ("speeddown", false);
		}

		else if (inputController.charge == false && inputController.slow == false) {

			Debug.Log ("neutral");


			animator.SetBool ("speedup", false);
			animator.SetBool ("neutral", true);
			animator.SetBool ("speeddown", false);
		}

		else if (inputController.charge == false && inputController.slow == true) {

			Debug.Log ("slowing");


			animator.SetBool ("speedup", false);
			animator.SetBool ("neutral", false);
			animator.SetBool ("speeddown", true);
		}

	}
}
