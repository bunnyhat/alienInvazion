using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SoundManagerScript : MonoBehaviour {
	
	public Slider volumeSlider;
	public Toggle volumeToggle;
	public AudioListener listner;
	public AudioClip audioClip;

	AudioSource m_audioSource;
	

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
		m_audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
		m_audioSource.volume = volumeSlider.value;
		AudioListener.volume = m_audioSource.volume;

		if(volumeToggle.isOn) {
			PlayerPrefs.SetInt("toggleON", 1);
			m_audioSource.volume = volumeSlider.value;
			// Debug.Log("volume is: " + PlayerPrefs.GetInt("toggleON"));
		} else {
			PlayerPrefs.SetInt("toggleON", 0);
			m_audioSource.volume = 0;
		}

		if(volumeSlider.value == m_audioSource.volume) {
			PlayerPrefs.SetFloat("volueLevel", volumeSlider.value);
		}

	}

	public void PlayButtonSound() {
		m_audioSource.PlayOneShot(audioClip, m_audioSource.volume);
	}
}
