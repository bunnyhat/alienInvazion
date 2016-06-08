using UnityEngine;
using System.Collections;

public class EnemyBeamScript : MonoBehaviour {

	public GameObject orangeExplosion;
	public GameObject blueExplosion;
	public GameObject purpleExplosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {

		if(other.gameObject.tag == "Player1") {
			if(other.gameObject.GetComponent<PlayerOneControllerScript>().lives > 0) {
				other.gameObject.GetComponent<PlayerOneControllerScript>().lives--;
			} else {
				other.gameObject.SetActive(false);
			}
			Destroy(this.gameObject);
			Instantiate(orangeExplosion, other.gameObject.transform.position, Quaternion.identity);
		}

		if(other.gameObject.tag == "Player2") {
			if(other.gameObject.GetComponent<PlayerTwoControllerScript>().lives > 0) {
				other.gameObject.GetComponent<PlayerTwoControllerScript>().lives--;
			} else {
				other.gameObject.SetActive(false);
			}
			Destroy(this.gameObject);
			Instantiate(orangeExplosion, other.gameObject.transform.position, Quaternion.identity);
		}
	}
}
