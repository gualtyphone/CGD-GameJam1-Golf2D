using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    private int[] players;
    private int numOfPlayers;
    public GameObject player;

    public void setNumOfPlayers(int numPlayers)
    {
        numOfPlayers = numPlayers;   
    }
    
    private void spawnPlayers()
    {
        players = new int[numOfPlayers];

        for (int i = 0; i < numOfPlayers; i++)
        {
            Instantiate(player, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
            if (i == 1)
            {
                player.GetComponent<Material>().color = Color.blue;
            }
            if (i == 2)
            {
                player.GetComponent<Material>().color = Color.red;
            }
            if (i == 3)
            {
                player.GetComponent<Material>().color = Color.green;
            }
            if (i == 4)
            {
                player.GetComponent<Material>().color = Color.yellow;
            }
        }
    }

    public void addScore(int playerNum, int score)
    {
        players[playerNum] += score;
    }

    public int[] getLeaderboard()
    {
         return players;
    }
}
