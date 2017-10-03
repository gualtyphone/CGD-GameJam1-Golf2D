using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
	public int[] players;
	//public GameObject panel;
	public int numOfPlayers;
	public GameObject p1;
	public GameObject p2;
	public GameObject p3;
	public GameObject p4;
  //  public GameObject player;
	// private MainMenuScript levelLoad;

    void Awake()
    {
		DontDestroyOnLoad(gameObject);
    }

    public void setNumOfPlayers(int numPlayers)
	{
		numOfPlayers = numPlayers;

		if (numPlayers == 2)
		{
			p1.SetActive (true);
			p2.SetActive (true);
			p3.SetActive (false);
			p4.SetActive (false);
		}
		else if (numPlayers == 3)
		{
			p1.SetActive (true);
			p2.SetActive (true);
			p3.SetActive (true);
			p4.SetActive (false);
		}
		else if (numPlayers == 4)
		{
			p1.SetActive (true);
			p2.SetActive (true);
			p3.SetActive (true);
			p4.SetActive (true);
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
