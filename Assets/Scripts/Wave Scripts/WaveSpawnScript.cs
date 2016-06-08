using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveSpawnScript : MonoBehaviour {

	public GameObject[] waves;

	public GameObject waveSpawnLocation;

	public float timer;
	public float waveStartTimer;
	public float waveRotationSpeed;

	public GameObject waveText;

    private GameObject currentWave;
	private bool startWave = false;
	private bool nextWaveStarted = false;
	
	PlayerOneControllerScript playerOne;
	PlayerTwoControllerScript playerTwo;

	// Use this for initialization
	void Start () {
		
		playerOne = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerOneControllerScript>();
		playerTwo = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerTwoControllerScript>();	    
	}
	
	// Update is called once per frame
	void Update () {
		
		waveText.SetActive(false);

		timer -= Time.deltaTime;
		if(timer <= 0) {
			if(startWave == false) {
				WaveStart();
			}
		}
		
		if(currentWave != null) {
			if(currentWave.GetComponent<EnemyCountScript>().waveDone) {
				timer = 3;
				startWave = false;
				Destroy(currentWave);
			}
		}
	}

	public void WaveStart() {

		waveText.SetActive(true);

		waveStartTimer -= Time.deltaTime;
		if(waveStartTimer <= 0) {
			waveText.SetActive(false);
            int randNum = Random.Range(0,waves.Length - 1);
			currentWave = Instantiate(waves[randNum], waveSpawnLocation.gameObject.transform.position, Quaternion.identity) as GameObject;
            
            startWave = true;
            waveStartTimer = 1.5f;
			
			nextWaveStarted = true;
			
			if(nextWaveStarted == true) {
				waveText.SetActive(true);
			}
		}
	}
}
