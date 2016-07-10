using UnityEngine;
using System.Collections;

public class PlatformDefinesScript : MonoBehaviour {

	public GameObject playerOnePcKeys, playerTwoPcKeys;
	public GameObject playerOneMobileKeys, playerTwoMobileKeys;

	// Use this for initialization
	void Update () {

		#if UNITY_EDITOR || UNITY_STANDALONE
			//Show pc controls
			playerOnePcKeys.SetActive(true);
			playerTwoPcKeys.SetActive(true);
			//Set pc controls text to center
			playerOnePcKeys.gameObject.transform.localPosition = new Vector2(0, 0);
			playerTwoPcKeys.gameObject.transform.localPosition = new Vector2(0, 0);
			//Hide mobile controls
			playerOneMobileKeys.SetActive(false);
			playerTwoMobileKeys.SetActive(false);


		#elif UNITY_ANDROID || UNITY_IPHONE
			//Show mobile controls
			playerOneMobileKeys.SetActive(true);
			playerTwoMobileKeys.SetActive(true);
			//Set mobile controls text to center
			playerOneMobileKeys.gameObject.transform.localPosition = new Vector2(0, 0);
			playerTwoMobileKeys.gameObject.transform.localPosition = new Vector2(0, 0);
			//Hide pc controls
			playerOnePcKeys.SetActive(false);
			playerTwoPcKeys.SetActive(false);
		#endif
	
	}
	
}
