using UnityEngine;
using System.Collections;

public class PlayerTwoBeamScript : MonoBehaviour {

	private PlayerTwoControllerScript playerTwoController;
	public GameObject orangeExplosion;
	public GameObject blueExplosion;
	public GameObject purpleExplosion;
	
	public AudioSource source;
	public AudioClip shipCrash;


	// Use this for initialization
	void Start () {
		
		playerTwoController = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerTwoControllerScript>();
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	public void crashAudio() {
		source.PlayOneShot(shipCrash,1);
	}

	void OnTriggerEnter2D(Collider2D other) {

		if(other.gameObject.tag == "UFO") {
			playerTwoController.getPoints(50.0f);
			Destroy(other.gameObject);
			Destroy(this.gameObject);
			Instantiate(blueExplosion, other.gameObject.transform.position, Quaternion.identity);
		}

		if(other.gameObject.tag == "Player1") {
			playerTwoController.getPoints(-10.0f);
			crashAudio();
			if(other.gameObject.GetComponent<PlayerOneControllerScript>().lives > 0) {
				other.gameObject.GetComponent<PlayerOneControllerScript>().lives--;
			} else {
				other.gameObject.SetActive(false);
			}
			Destroy(this.gameObject);
			Instantiate(orangeExplosion, other.gameObject.transform.position, Quaternion.identity);
		}
	}		
}
