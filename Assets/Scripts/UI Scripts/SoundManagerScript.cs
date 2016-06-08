using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SoundManagerScript : MonoBehaviour {
	
	public Slider volumeSlider;
	public AudioSource audioSource;
	public AudioListener listner;
	

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
		audioSource.volume = volumeSlider.value / 100;
		AudioListener.volume = audioSource.volume * 10;

	}
}
