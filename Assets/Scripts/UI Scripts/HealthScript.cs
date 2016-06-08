using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {
		
	public GameObject playerOneHpBar;
	public GameObject playerTwoHpBar;
	
	PlayerOneControllerScript playerOne;
	PlayerTwoControllerScript playerTwo;


	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
		
		playerOne = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerOneControllerScript>();
		playerTwo = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerTwoControllerScript>();
	}
	
	// Update is called once per frame
	void Update () {	
		playerOneHpBar.transform.localScale = new Vector3(playerOne.lives + 0.5f, playerOneHpBar.transform.localScale.y, playerOneHpBar.transform.localScale.z);
		playerTwoHpBar.transform.localScale = new Vector3(playerTwo.lives + 0.5f, playerTwoHpBar.transform.localScale.y, playerTwoHpBar.transform.localScale.z);
		
		if(playerOne.lives == 0) {
			playerOneHpBar.transform.localScale = new Vector3(0, playerOneHpBar.transform.localScale.y, playerOneHpBar.transform.localScale.z);
			playerOneHpBar.SetActive(false);
		}
		if(playerTwo.lives == 0) {
			playerTwoHpBar.transform.localScale = new Vector3(0, playerTwoHpBar.transform.localScale.y, playerTwoHpBar.transform.localScale.z);
			playerTwoHpBar.SetActive(false);
		}	
	}
}
