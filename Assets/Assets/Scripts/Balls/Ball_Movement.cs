using UnityEngine;
using System.Collections;

public class Ball_Movement : MonoBehaviour {

	public bool isFrozen;
	public bool paddleCharged;
	public bool paddleSlowed;

	public int startSpeed;
	public int newSpeed;
	public int minSpeed;
	public int maxSpeed;
	public Rigidbody2D rigidBody2D;

	public GameObject playerOne;
	public GameObject playerTwo;
	public bool hitPlayerOne;
	public bool hitPlayerTwo;

	//get inputs
	private Paddle_Charger paddleChargerP1;
	private Paddle_Charger paddleChargerP2;

	void OnEnable () {

		if (rigidBody2D == null) {
		
			rigidBody2D = GetComponent<Rigidbody2D> ();
		}

		//get inputs
		if (paddleChargerP1 == null) {

			paddleChargerP1 = playerOne.GetComponent<Paddle_Charger> ();
		}

		//get inputs
		if (paddleChargerP2 == null) {

			paddleChargerP2 = playerTwo.GetComponent<Paddle_Charger> ();
		}

		isFrozen = true;
		paddleCharged = false;
		startSpeed = 2;
		newSpeed = startSpeed;
		minSpeed = 1;
		maxSpeed = 7;


		Invoke ("Thaw", 1F);
		PickDirection ();
	}

	void FixedUpdate () {

		if (isFrozen == false) {
			MoveBall ();
		}
	}

	void Thaw () {

		isFrozen = false;
	}

	void PickDirection () {
	
		float randomDirection = Random.Range (-360, 360);

		transform.RotateAround(Vector3.zero, Vector3.forward, randomDirection);
	}

	void MoveBall () {

		rigidBody2D.AddRelativeForce(transform.up * startSpeed);

		//later change this to set different speeds
		//int newSpeed = 3;
		rigidBody2D.velocity = newSpeed * (rigidBody2D.velocity.normalized);
	}

	void ChangeSpeed () {

		//increase speed
		if (paddleCharged == true) {
	
			if (newSpeed < maxSpeed) {
			
				newSpeed = newSpeed + 1;
				//Debug.Log (newSpeed);
			}

			//Debug.Log (newSpeed);
		}

		//decrease speed
		if (paddleSlowed == true) {

			if (newSpeed > minSpeed) {

				newSpeed = newSpeed - 1;
				//Debug.Log (newSpeed);
			}

			//Debug.Log (newSpeed);
		}

		Debug.Log (newSpeed);
	}

	void OnCollisionEnter2D(Collision2D other) {

		//manual bounce instead of using physics material
		if (other.gameObject.tag == "Player") {

			//logs the collision vector data in an array
			ContactPoint2D contact = other.contacts[0]; 
			Vector2 collisionPoint = contact.point;

			//Following formula  v' = 2 * (v . n) * n - v
			rigidBody2D.velocity = 2 * (Vector2.Dot (rigidBody2D.velocity, collisionPoint)) * collisionPoint - rigidBody2D.velocity;

			//have to multiply everything by -1
			rigidBody2D.velocity *= -1;
		}

		if (other.gameObject.name == "Player 1") {

			hitPlayerOne = true;
			hitPlayerTwo = false;

			HitPlayerOne ();
			//ChangeSpeed ();
		}

		if (other.gameObject.name == "Player 2") {

			hitPlayerOne = false;
			hitPlayerTwo = true;

			HitPlayerTwo ();
			//ChangeSpeed ();
		}
	}

	void HitPlayerOne () {

		//hit player one
		if (hitPlayerOne && paddleChargerP1.playerOneCharging) {

			paddleCharged = true;
		} else if (hitPlayerOne && paddleChargerP1.playerOneCharging == false) {

			paddleCharged = false;
		}

		if (hitPlayerOne && paddleChargerP1.playerOneSlowing) {

			paddleSlowed = true;
		} else if (hitPlayerOne && paddleChargerP1.playerOneSlowing == false) {

			paddleSlowed = false;
		}

		ChangeSpeed ();
	}

	void HitPlayerTwo () {

		//hit player two
		if (hitPlayerTwo && paddleChargerP2.playerTwoCharging) {

			paddleCharged = true;
		} else if (hitPlayerTwo && paddleChargerP2.playerTwoCharging == false) {

			paddleCharged = false;
		}

		if (hitPlayerTwo && paddleChargerP2.playerTwoSlowing) {

			paddleSlowed = true;
		} else if (hitPlayerTwo && paddleChargerP2.playerTwoSlowing == false) {

			paddleSlowed = false;
		}

		ChangeSpeed ();
	}



	/*
	void OnCollisionEnter2D(Collision2D other) {

		//manual bounce instead of using physics material
		if (other.gameObject.tag == "Player") {

			//logs the collision vector data in an array
			ContactPoint2D contact = other.contacts[0]; 
			Vector2 collisionPoint = contact.point;

			//Following formula  v' = 2 * (v . n) * n - v
			rigidBody2D.velocity = 2 * (Vector2.Dot (rigidBody2D.velocity, collisionPoint)) * collisionPoint - rigidBody2D.velocity;

			//have to multiply everything by -1
			rigidBody2D.velocity *= -1;
		}
	}
	*/
}