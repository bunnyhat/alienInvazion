using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManagerScript : MonoBehaviour {

	// <summary>
	[Header("Game Over screen variables")]
	public float timer;	
	public GameObject playerOne;
	public GameObject playerTwo;
	public Text playerOneFinalScore;
	public Text playerTwoFinalScore;
	public GameObject gameOverCanvas;
	//Game Objects that need to be disabled when game over canvas is called.
	public GameObject waveCanvas, mainCanvas;
	
	private static bool isGameOver = false;
	// </summary>

	// <summary>
	[Header("Pause screens variables")]
	public Canvas playerOnePauseGUI;
	public Canvas playerTwoPauseGUI;
	public GameObject playerOneHud, playerTwoHud;
	public GameObject incomingWave;
	
	private bool isPlayerOnePaused, isPlayerTwoPaused;
	// </summary>

	// <summary>
	[Header("Score variables")]
	public Text playerOneScoreText;
	public Text playerTwoScoreText;
	public float playerOneScore;
	public float playerTwoScore;
	// </summary>

	// <summary>
	[Header("Wave Spawn variables")]
	public GameObject[] waves;
	public GameObject waveSpawnLocation;
	public float waveSpawnTimer;
	public float waveStartTimer;
	public GameObject waveText;

    private GameObject currentWave;
	private bool startWave = false;
	private bool nextWaveStarted = false;
	// </summary>

	WaveSpawnScript m_waveSpawnScript;
	PlayerOneControllerScript m_playerOneController;
	PlayerTwoControllerScript m_playerTwoController;

	// private static GameManagerScript _instance;
    // public static GameManagerScript Instance { get { return _instance; } }
    // private void Awake() {
    //     if (_instance != null) {
    //         Destroy(this.gameObject);
    //     } else {
    //         _instance = this;
    //     }
    // }

	void Start() {
		Time.timeScale = 1;

		m_waveSpawnScript = GetComponent<WaveSpawnScript>();
		m_playerOneController = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerOneControllerScript>();	
		m_playerTwoController = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerTwoControllerScript>();

		gameOverCanvas.SetActive(false);
		isGameOver = false;

		isPlayerOnePaused = false;
		isPlayerTwoPaused = false;
		playerOnePauseGUI.enabled = false;
		playerTwoPauseGUI.enabled = false;
	}

	void Update() {

		isGameOver = false;
		
		if(!playerOne.activeInHierarchy) {
			m_playerOneController.enabled = false;
		}
		if(!playerTwo.activeInHierarchy) {
			m_playerTwoController.enabled = false;
		}

		if(!playerOne.activeInHierarchy && !playerTwo.activeInHierarchy && !isGameOver) {
			isGameOver = true;
			m_playerOneController.enabled = false;
			m_playerTwoController.enabled = false;
			
			GameOver();
			if(!gameOverCanvas.activeInHierarchy) {
				//Show the final score of player 1 and 2
				playerOneFinalScore.text = playerOneScore.ToString();
				playerTwoFinalScore.text = playerTwoScore.ToString();				
			}
		}

		if(Input.GetKey(KeyCode.P) || isPlayerOnePaused) {
			Time.timeScale = 0;
			
			isPlayerOnePaused = true;
			playerOnePauseGUI.enabled = true;
			playerOneHud.SetActive(false);
			playerTwoHud.SetActive(false);
			if(incomingWave.activeInHierarchy) {
				incomingWave.SetActive(false);
			}
		}
		
		if(Input.GetKey(KeyCode.O) || isPlayerTwoPaused) {
			Time.timeScale = 0;
			
			isPlayerTwoPaused = true;
			playerTwoPauseGUI.enabled = true;
			playerTwoHud.SetActive(false);
			playerOneHud.SetActive(false);
			if(incomingWave.activeInHierarchy) {
				incomingWave.SetActive(false);
			}
		}


		GetScore();
		playerOneScoreText.text = playerOneScore.ToString();
		playerTwoScoreText.text = playerTwoScore.ToString();


		waveText.SetActive(false);

		waveSpawnTimer -= Time.deltaTime;
		if(waveSpawnTimer <= 0) {
			if(startWave == false) {
				WaveStart();
			}
		}
		
		if(currentWave != null) {
			if(currentWave.GetComponent<EnemyCountScript>().waveDone) {
				waveSpawnTimer = 3;
				startWave = false;
				Destroy(currentWave);
			}
		}

		GetVolumeSetting();
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

	public void GetScore() {
		playerOneScore = m_playerOneController.score;
		playerTwoScore = m_playerTwoController.score;			
	}

	public void GameOver() {
		isGameOver = !isGameOver;
		//Allows for game to be idle till timer reaches 0 to call the game over canvas
		timer -= Time.deltaTime;
		if(timer <= 0) {
			Time.timeScale = 0;
			waveCanvas.SetActive(false);
			mainCanvas.SetActive(false);
			GameObject.FindGameObjectWithTag("Enemy").SetActive(false);
			gameOverCanvas.SetActive(true);
		}
	}
	
	public void MainMenu() {
		Time.timeScale = 1;
		SceneManager.LoadScene("mainScene");
	}
	
	public void QuitGame() {
		Application.Quit();
	}

	public void GetVolumeSetting() {

		if(PlayerPrefs.GetInt("toggleON") == 1) {
			PlayerPrefs.GetInt("toggleON");
			PlayerPrefs.GetFloat("volumeLevel");
		}
	}

		public void PlayerOnePaused() {
		isPlayerOnePaused = !isPlayerOnePaused;
	}
	
	public void PlayerTwoPaused() {
		isPlayerTwoPaused = !isPlayerTwoPaused;
	}
	
	public void ResumeGame() {
		Time.timeScale = 1;
		
		isPlayerOnePaused = false;
		isPlayerTwoPaused = false;
		
		playerOnePauseGUI.enabled = false;
		playerTwoPauseGUI.enabled = false;	

		playerOneHud.SetActive(true);
		playerTwoHud.SetActive(true);
	}
}
