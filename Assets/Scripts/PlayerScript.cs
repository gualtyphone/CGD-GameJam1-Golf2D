using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public int numOfPlayers = 0;
    private int[] players; 
    public int p1score;
    public int p2score;
    public int p3score;
    public int p4score;

    public void playerSpawn(int numPlayers)
    {
        players = new int[numPlayers];

        numOfPlayers = numPlayers;
    }
    
    public void addScore()
    {
        
    }

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
