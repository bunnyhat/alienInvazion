using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverManagerScript : MonoBehaviour {
	
	public float timer;
	
	public GameObject playerOne;
	public GameObject playerTwo;
	public Text playerOneFinalScore;
	public Text playerTwoFinalScore;
	public GameObject gameOverCanvas;
	
	//Game Objects that need to be disabled when game over canvas is called.
	public GameObject waveCanvas, mainCanvas;
	
	private static bool isGameOver = false;
	
	
	SceneManagerScript m_sceneManager;
	ScoreManagerScript m_scoreScript;
	WaveSpawnScript m_waveSpawnScript;
	PlayerOneControllerScript m_playerOneController;
	PlayerTwoControllerScript m_playerTwoController;

	// Use this for initialization
	void Start () {
		
		DontDestroyOnLoad(this);
		gameOverCanvas.SetActive(false);
		
		isGameOver = false;
		
		m_sceneManager = GetComponent<SceneManagerScript>();
		m_scoreScript = GetComponent<ScoreManagerScript>();
		m_waveSpawnScript = GetComponent<WaveSpawnScript>();
		m_playerOneController = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerOneControllerScript>();	
		m_playerTwoController = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerTwoControllerScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
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
				playerOneFinalScore.text = m_scoreScript.playerOneScore.ToString();
				playerTwoFinalScore.text = m_scoreScript.playerTwoScore.ToString();				
			}
		}
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
	
}
