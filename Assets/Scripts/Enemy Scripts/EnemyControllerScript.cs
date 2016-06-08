using UnityEngine;
using System.Collections;

public class EnemyControllerScript : MonoBehaviour {

	public float moveSpeed;
	public float rateOfFire;
	public GameObject UfoBeam;
	public GameObject UfoBeam2;
	public Rigidbody2D beamPrefab;
	public Rigidbody2D beam2Prefab;
	public Transform UfoEnd;


	private bool movingRight = true;
	private bool isAlive;
	private bool isUfoShooting = true;
	private float timerReset;

//	EdgeCollider2D m_edgeCollider;

	Animator m_animator;

	// Use this for initialization
	void Start () {

		m_animator = GetComponent<Animator>();

		isAlive = true;	
	}
	
	// Update is called once per frame
	void Update () {

		if(movingRight) {
			MoveRight();
		} else {
			MoveLeft();
		}
			
	}

	private void MoveLeft() {
		transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
	}

	private void MoveRight() {
		transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
	}

	private void UFOFireAtPlayer1() {
		isUfoShooting = false;
		UfoBeam.SetActive(true);
		Rigidbody2D UFObeamInstance;
		UFObeamInstance = Instantiate(beamPrefab, UfoEnd.position, UfoEnd.rotation) as Rigidbody2D;
	}
	private void UFOFireAtPlayer2() {
		isUfoShooting = false;
		UfoBeam2.SetActive(true);
		Rigidbody2D UFObeamInstance;
		UFObeamInstance = Instantiate(beam2Prefab, UfoEnd.position, UfoEnd.rotation) as Rigidbody2D;
	}

	void OnTriggerStay2D(Collider2D other) {

		if(other.gameObject.name == "LeftCollider") {
			movingRight = true;
		}
		if(other.gameObject.name == "RightCollider") {
			movingRight = false;
		}

		if(other.gameObject.tag == "Player1") {
			timerReset -= Time.deltaTime;
			if(timerReset <= 0) {
				isUfoShooting = true;
				UFOFireAtPlayer1();
				timerReset = rateOfFire;
			}
		}
		if(other.gameObject.tag == "Player2") {
			timerReset -= Time.deltaTime;
			if(timerReset <= 0) {
				isUfoShooting = true;
				UFOFireAtPlayer2();
				timerReset = rateOfFire;
			}
		}
	}

}
