using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScene : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        Application.LoadLevel(1);
        FindObjectOfType<GameManager>().needsUpdating = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
