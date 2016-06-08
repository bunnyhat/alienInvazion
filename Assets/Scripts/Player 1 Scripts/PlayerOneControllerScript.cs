using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, yMin, yMax;
}

public class PlayerOneControllerScript : MonoBehaviour {

	public float craftSpeed;
	public float beamSpeed;
	public float score;
	public float lives;
	
	public AudioSource source;
	public AudioClip laserBeam;
	

	public GameObject beam;
	public Rigidbody2D beamPrefab;
	public Transform shipEnd;
	public Boundary boundary;

	private bool movingLeft = false;
	private bool movingRight = false;
	
	private float volLowRange = 0.1f;
    private float volHighRange = 0.3f;

	Animator m_animator;
	Rigidbody2D m_rigidbody2D;

	// Use this for initialization
	void Start () {

		score = 0.0f;

		m_animator = GetComponent<Animator>();
		m_rigidbody2D = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		
		if(Input.GetKey(KeyCode.A) || movingLeft) {
			transform.position = new Vector3(transform.position.x - craftSpeed * Time.deltaTime, transform.position.y, transform.position.z);
		}
		if(Input.GetKey(KeyCode.D) || movingRight) {
			transform.position = new Vector3(transform.position.x + craftSpeed * Time.deltaTime, transform.position.y, transform.position.z);
		}

		if(transform.position.x <= -3.5f) {
			transform.position = new Vector2(-3.5f, transform.position.y);
		}
		if(transform.position.x >= 3.5f) {
			transform.position = new Vector2(3.5f, transform.position.y);
		}

		if (Input.GetKeyDown(KeyCode.Space)) {
			Player1Fire();
		}
	}
	
	public void HandleMoveLeft() {
		movingLeft = !movingLeft;
	}
	
	public void HandleMoveRight() {
		movingRight = !movingRight;
	}
	
	public void MoveLeft() {
		transform.position = new Vector3(transform.position.x - craftSpeed * Time.deltaTime, transform.position.y, transform.position.z);
	}
	
	public void MoveRight() {
		transform.position = new Vector3(transform.position.x + craftSpeed * Time.deltaTime, transform.position.y, transform.position.z);
	}

	public void Player1Fire() {
		
		if(this.gameObject.activeInHierarchy) {
			beam.SetActive(true);
			
			float vol = Random.Range (volLowRange, volHighRange);
			source.PlayOneShot(laserBeam,vol);
				
			Rigidbody2D beamInstance;
			beamInstance = Instantiate(beamPrefab, shipEnd.position, shipEnd.rotation) as Rigidbody2D;
		}
	}

	public void getPoints(float points) {
		score += points;
	}
}
