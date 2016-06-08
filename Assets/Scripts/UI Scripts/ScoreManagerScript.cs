using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManagerScript : MonoBehaviour {

	public Text playerOneScoreText;
	public Text playerTwoScoreText;
	public float playerOneScore;
	public float playerTwoScore;

	PlayerOneControllerScript m_playerOneController;
	PlayerTwoControllerScript m_playerTwoController;

	// Use this for initialization
	void Start () {
		
		DontDestroyOnLoad(this);
		
		m_playerOneController = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerOneControllerScript>();
		m_playerTwoController = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerTwoControllerScript>();

	}
	
	// Update is called once per frame
	void Update () {

		GetScore();

		playerOneScoreText.text = playerOneScore.ToString();
		playerTwoScoreText.text = playerTwoScore.ToString();

	}

	public void GetScore() {

		playerOneScore = m_playerOneController.score;
		playerTwoScore = m_playerTwoController.score;			
	}
	
}
