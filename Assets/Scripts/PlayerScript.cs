using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public int numOfPlayers = 0;
    public int[] players;
    public GameObject player;

    public void playerSpawn(int numPlayers)
    {
        players = new int[numPlayers];

        numOfPlayers = numPlayers;

        for (int i = 0; i < numPlayers; i++)
        {
            Instantiate(player, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
        }
    }
    
    public void addScore(int playerNum, int score)
    {
        players[playerNum] += score;
    }

//    // Use this for initialization
//    void Start () {
       
//    }
	
//	// Update is called once per frame
//	void Update () {
        
//	}
}
