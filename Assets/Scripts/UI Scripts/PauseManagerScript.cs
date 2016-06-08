using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseManagerScript : MonoBehaviour {
	
	public GameObject playerOne;
	public GameObject playerTwo;
	
	public Canvas playerOnePauseGUI;
	public Canvas playerTwoPauseGUI;
	
	private bool isPlayerOnePaused;
	private bool isPlayerTwoPaused;
	
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
			
		}
		
		if(Input.GetKey(KeyCode.O) || isPlayerTwoPaused) {
			Time.timeScale = 0;
			
			isPlayerTwoPaused = true;
			playerTwoPauseGUI.enabled = true;
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
	}
	
	public void MainMenu() {
		Time.timeScale = 1;
		SceneManager.LoadScene("mainScene");
	}
}
