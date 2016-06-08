using UnityEngine;
using System.Collections;

public class PlayerOneBeamScript : MonoBehaviour {
	
	private PlayerOneControllerScript playerOneController;
	public GameObject orangeExplosion;
	public GameObject blueExplosion;
	public GameObject purpleExplosion;
	
	public AudioSource source;
	public AudioClip shipCrash;
	

	// Use this for initialization
	void Start () {
		
		playerOneController = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerOneControllerScript>();
	}

	// Update is called once per frame
	void Update () {	
		
	}
	
	public void crashAudio() {
		source.PlayOneShot(shipCrash,1);
	}
	void OnTriggerEnter2D(Collider2D other) {

		if(other.gameObject.tag == "UFO") {
			playerOneController.getPoints(50.0f);
			Destroy(other.gameObject);
			Destroy(this.gameObject);
			Instantiate(blueExplosion, other.gameObject.transform.position, Quaternion.identity);
		}

		if(other.gameObject.tag == "Player2") {
			playerOneController.getPoints(-10.0f);
			crashAudio();
			if(other.gameObject.GetComponent<PlayerTwoControllerScript>().lives > 0) {
				other.gameObject.GetComponent<PlayerTwoControllerScript>().lives--;
				
			} else {
				other.gameObject.SetActive(false);
			}
			Instantiate(orangeExplosion, other.gameObject.transform.position, Quaternion.identity);
		}
	}
}