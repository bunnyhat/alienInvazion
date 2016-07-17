using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneManagerScript : MonoBehaviour {
	
	public GameObject mainMenuContainer, settingsContainer, creditsContainer;
	public bool onMainMenu;
	
	WaveSpawnScript waveSpawn;		

	// Use this for initialization
	void Start () {
		//DontDestroyOnLoad(this);
		
		onMainMenu = true;
		
		waveSpawn = GetComponent<WaveSpawnScript>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void PlayGame() {
		SceneManager.LoadScene("gameScene");
		onMainMenu = false;
	}

	public void Options() {
		mainMenuContainer.SetActive(false);
		settingsContainer.SetActive(true);
	}

	public void BackToMMenuButton() {
		settingsContainer.SetActive(false);	
		mainMenuContainer.SetActive(true);
	}

	public void CreditsButton() {
		settingsContainer.SetActive(false);
		creditsContainer.SetActive(true);
	}

	public void BackToOptionsButton() {
		creditsContainer.SetActive(false);
		settingsContainer.SetActive(true);
	}
	
	public void QuitGame() {
		Application.Quit();
	}

}
