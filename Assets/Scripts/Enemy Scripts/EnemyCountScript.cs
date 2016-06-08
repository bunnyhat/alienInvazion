using UnityEngine;
using System.Collections;

public class EnemyCountScript : MonoBehaviour {
    
    public bool waveDone;
    private Transform[] ts;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        ts = gameObject.GetComponentsInChildren<Transform>();
        
        if(ts.Length - 1 == 0 && !waveDone) {
            waveDone = true;
            Debug.Log("ts.Length");
        }
	
	}
}
