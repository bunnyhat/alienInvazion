using UnityEngine;
using System.Collections;

public class PlatformDefinesScript : MonoBehaviour {

	public GameObject playerOnePcKeys, playerTwoPcKeys;
	public GameObject playerOneMobileKeys, playerTwoMobileKeys;

	// Use this for initialization
	void Start () {

		#if UNITY_EDITOR || UNITY_STANDALONE
			//Set pc controls text to center
			playerOnePcKeys.gameObject.transform.localPosition = new Vector2(0, 0);
			playerTwoPcKeys.gameObject.transform.localPosition = new Vector2(0, 0);
			//Hide mobile controls
			playerOneMobileKeys.SetActive(false);
			playerTwoMobileKeys.SetActive(false);
		#endif

		#if UNITY_ANDROID || UNITY_IPHONE
			//Set mobile controls text to center
			playerOneMobileKeys.gameObject.transform.localPosition = new Vector2(0, 0);
			playerTwoMobileKeys.gameObject.transform.localPosition = new Vector2(0, 0);
			//Hide pc controls
			playerOnePcKeys.SetActive(false);
			playerTwoPcKeys.SetActive(false);
		#endif
	
	}
	
}
