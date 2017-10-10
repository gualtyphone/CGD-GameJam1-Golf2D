using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayScore : MonoBehaviour {


    public GUIText allPlayersScore;

  
    int[] playerScore = new int[4] { 0, 0, 0, 0};
    
    

    PlayerScript ps;

    // Use this for initialization
    void Start () {
        ps = GameObject.FindObjectOfType<PlayerScript>();
        
    }

      // Update is called once per frame
    void Update () {

        if (ps.numOfPlayers == 1)
        {
            playerScore[0] = ps.getLeaderboard()[0];
            allPlayersScore.text = "SCORE: \nPlayer 1 (Blue): " + playerScore[0];
        }

        else if (ps.numOfPlayers == 2)
        {
            playerScore[0] = ps.getLeaderboard()[0];
            playerScore[1] = ps.getLeaderboard()[1];
            allPlayersScore.text = "SCORE: \nPlayer 1 (Blue): " + playerScore[0] + "\nPlayer 2 (Red): " + playerScore[1];
        }
        else if (ps.numOfPlayers == 3)
        {
            playerScore[0] = ps.getLeaderboard()[0];
            playerScore[1] = ps.getLeaderboard()[1];
            playerScore[2] = ps.getLeaderboard()[2];
            allPlayersScore.text = "SCORE: \nPlayer 1 (Blue): " + playerScore[0] + "\nPlayer 2 (Red): " + playerScore[1] + "\nPlayer 3 (Pink): " + playerScore[2];
        }
        else if (ps.numOfPlayers == 4)
        {
            playerScore[0] = ps.getLeaderboard()[0];
            playerScore[1] = ps.getLeaderboard()[1];
            playerScore[2] = ps.getLeaderboard()[2];
            playerScore[3] = ps.getLeaderboard()[3];
            allPlayersScore.text = "SCORE: \nPlayer 1 (Blue): " + playerScore[0] + "\nPlayer 2 (Red): " + playerScore[1] + "\nPlayer 3 (Pink): " + playerScore[2] + "\nPlayer 4 (Yellow): " + playerScore[3];

        }
    }
}
