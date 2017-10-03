using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    public List<Sprite> maps;
    public List<Sprite> heatMaps;

    public int map = 0;
    public bool needsUpdating = true;


    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start () {
        //maps = new List<Sprite>();
	}
	
	// Update is called once per frame
	void Update () {
        if (needsUpdating && Application.loadedLevel == 1)
        {
            Destroy(FindObjectOfType<Hole>().gameObject);
            FindObjectOfType<HeatMap>().gameObject.GetComponent<SpriteRenderer>().sprite = heatMaps[map];
            FindObjectOfType<TextureMap>().gameObject.GetComponent<SpriteRenderer>().sprite = maps[map];
            FindObjectOfType<HeatMap>().enabled = false;
            FindObjectOfType<HeatMap>().enabled = true;
            FindObjectOfType<TextureMap>().enabled = false;
            FindObjectOfType<TextureMap>().enabled = true;
            needsUpdating = false;
            
        }
        //loadTexture("level" + levelNumber)
        //loadTexture("Level" + levelNumber

    }
}
