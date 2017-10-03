using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
	public int[] players;

	public int numOfPlayers;
  //  public GameObject player;
	// private MainMenuScript levelLoad;

    void Awake()
    {
		DontDestroyOnLoad(gameObject);
    }

    public void setNumOfPlayers(int numPlayers)
	{
		numOfPlayers = numPlayers;
		GetComponent<MainMenuScript> ().loadLevel (1);
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
