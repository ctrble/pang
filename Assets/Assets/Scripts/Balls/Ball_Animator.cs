using UnityEngine;
using System.Collections;

public class Ball_Animator : MonoBehaviour {

	//the animator
	public Animator animator;

	//get charger
	private Ball_Movement ballMovement;

	void OnEnable () {

		//get the animator
		if (animator == null) {
			animator = GetComponent<Animator> ();
		}

		//get speed
		if (ballMovement == null) {

			ballMovement = GetComponentInParent<Ball_Movement> ();
		}
	}

	void Update() {
	
		if (ballMovement.newSpeed > ballMovement.startSpeed) {
		
			animator.SetBool ("speedup", true);
			animator.SetBool ("neutral", false);
			animator.SetBool ("speeddown", false);
		}

		if (ballMovement.newSpeed == ballMovement.startSpeed) {

			animator.SetBool ("speedup", false);
			animator.SetBool ("neutral", true);
			animator.SetBool ("speeddown", false);
		}

		if (ballMovement.newSpeed < ballMovement.startSpeed) {

			animator.SetBool ("speedup", false);
			animator.SetBool ("neutral", false);
			animator.SetBool ("speeddown", true);
		}

	}
}
