using UnityEngine;
using System.Collections;

// [System.Serializable]
// public class Boundary {
// 	public float xMin, xMax, yMin, yMax;
// }

public class EnemyBehaviourScript : MonoBehaviour {

	public float moveSpeed, spinSpeed;

	private bool movingRight = true;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log(movingRight);

		if(transform.position.x == -6f) {
			MoveRight();
			transform.position = new Vector3(-6f, transform.position.y, transform.position.z);
		}
		if(transform.position.x >= 6f) {
			MoveLeft();
			transform.position = new Vector3(6f, transform.position.y, transform.position.z);
		}
		
		if(movingRight) {
			MoveRight();
		} else {
			MoveLeft();
		}
	
	}

	private void MoveLeft() {
		transform.Rotate(Vector3.up, -spinSpeed * Time.deltaTime);
		// transform.position = new Vector3(-6f, transform.position.y, transform.position.z);
		// transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
	}
	private void MoveRight() {
		transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
		// transform.position = new Vector3(6f, transform.position.y, transform.position.z);
		// transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
	}

	void OnTriggerStay2D(Collider2D other) {

		if(other.gameObject.name == "LeftCollider") {
			movingRight = true;
		}
		if(other.gameObject.name == "RightCollider") {
			movingRight = false;
		}
	}

}
