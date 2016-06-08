using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {
	
	private static GameManagerScript _instance;

	// Use this for initialization
	void Awake() {
		
		//If we don't have an [_instance] set yet
		if(!_instance) {
			_instance = this;
			
		} else {
			//otherwise if we do, kill this thing
			Destroy(_instance.gameObject);
		}
		
		DontDestroyOnLoad(this);
	}
}
