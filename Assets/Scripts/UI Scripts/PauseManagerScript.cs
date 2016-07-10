using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseManagerScript : MonoBehaviour {
	
	public GameObject playerOne, playerTwo;
	public Canvas playerOnePauseGUI, playerTwoPauseGUI;
	public GameObject playerOneHud, playerTwoHud;
	public GameObject incomingWave;
	
	private bool isPlayerOnePaused, isPlayerTwoPaused;
	
	GameOverManagerScript m_gameOverScript;

	// Use this for initialization
	void Start () {
		
		DontDestroyOnLoad(this);
		
		isPlayerOnePaused = false;
		isPlayerTwoPaused = false;
		
		playerOnePauseGUI.enabled = false;
		playerTwoPauseGUI.enabled = false;
		
		m_gameOverScript = GetComponent<GameOverManagerScript>();
	}
	
	// Update is called once per frame
	void Update () {
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
	
	public void MainMenu() {
		Time.timeScale = 1;
		SceneManager.LoadScene("mainScene");
	}
}
