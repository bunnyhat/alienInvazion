using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneManagerScript : MonoBehaviour {
	
	public bool onMainMenu;
	
	WaveSpawnScript waveSpawn;		

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
		
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
	
	public void QuitGame() {
		Application.Quit();
	}
	
	// public void CanvasToggle() {
		
	// 	if(onMainMenu == false) {
	// 		waveSpawn.GetComponent<WaveSpawnScript>().enabled = true;
	// 	}
	// }
}
