using UnityEngine;
using System.Collections;

public class BGController : MonoBehaviour {

	SpriteRenderer m_spriteRenderer;

	GameManagerScript m_gameManager;

	// Use this for initialization
	void Start () {
		m_spriteRenderer = GetComponent<SpriteRenderer>();
		m_gameManager = GetComponent<GameManagerScript>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if(m_gameManager.isGameOver == true) {
			m_spriteRenderer.sortingOrder = 50;
		}
	}

}
