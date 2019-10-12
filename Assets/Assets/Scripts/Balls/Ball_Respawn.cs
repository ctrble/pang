using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Ball_Respawn : MonoBehaviour {

	void OnTriggerExit2D(Collider2D other) {


		if (other.gameObject.tag == "Bounds") {
		
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}
