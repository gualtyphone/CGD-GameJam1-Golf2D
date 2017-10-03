using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyColorSprite : MonoBehaviour {

    public SpriteRenderer other;
    public SpriteRenderer mine;

    // Use this for initialization
    void Start () {
        mine = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        mine.color = other.color;
	}
}
