using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    private int[] players;
    private int numOfPlayers;
    public GameObject player;
	public GameObject playerManager;
   // private MainMenuScript levelLoad;

    void start()
    {
        DontDestroyOnLoad(playerManager);
    }

	[SerializeField]
	public GameObject ball;

	GameObject instantiatePlayer(Color col, KeyCode button)
	{
		GameObject player = Instantiate(ball);
		player.GetComponent<BallController>().heatmap = GameObject.FindObjectOfType<HeatMap>();
		player.GetComponent<BallController>().texMap = GameObject.FindObjectOfType<TextureMap>();
		player.transform.position = player.GetComponent<BallController>().texMap.startPos;
		player.GetComponent<SpriteRenderer>().color = col;
		SpriteRenderer[] renderers = player.GetComponentsInChildren<SpriteRenderer>();
		foreach(var r in renderers)
		{
			r.color = col;
		}
		player.GetComponentInChildren<powerBar>().playerKey = button;
		return player;
	}


    public void setNumOfPlayers(int numPlayers)
    {
        numOfPlayers = numPlayers;
		spawnPlayers ();
    }
    
    public void spawnPlayers()
    {
		playerManager.GetComponent<MainMenuScript>().loadLevel(1);
        players = new int[numOfPlayers];

        for (int i = 0; i < numOfPlayers; i++)
        {
            if (i == 1)
            {
				instantiatePlayer(Color.blue, KeyCode.A);
            }
            if (i == 2)
            {
				instantiatePlayer(Color.blue, KeyCode.A);
            }
            if (i == 3)
            {
				instantiatePlayer(Color.blue, KeyCode.A);
            }
            if (i == 4)
            {
				instantiatePlayer(Color.blue, KeyCode.A);
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
