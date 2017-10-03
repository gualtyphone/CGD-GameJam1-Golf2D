using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboadScript : MonoBehaviour {

	private Vector2 position1;
	private Vector2 position2;
	private Vector2 position3;
	private Vector2 position4;

	private int player1Score = 0;
	private int player2Score = 0;
	private int player3Score = 0;
	private int player4Score = 0;

	PlayerScript ps;

	// Use this for initialization
	void Start () {
		ps = GameObject.FindObjectOfType<PlayerScript> ();
		position1.y = -249.7f;
		position2.y = -296.1f;
		position3.y = -343.5f;
		position4.y = -390.9f;

		if (ps.numOfPlayers == 2) 
		{
			player1Score = ps.getLeaderboard() [0];
			player2Score = ps.getLeaderboard ()[1];
		}
		else if (ps.numOfPlayers == 3) 
		{
			player1Score = ps.getLeaderboard() [0];
			player2Score = ps.getLeaderboard() [1];
			player3Score = ps.getLeaderboard() [2];
		}
		else if (ps.numOfPlayers == 4) 
		{	player1Score = ps.getLeaderboard() [0];
			player2Score = ps.getLeaderboard() [1];
			player3Score = ps.getLeaderboard() [2];
			player4Score = ps.getLeaderboard() [3];
		}

		createLeaderboard ();
	}

	void createLeaderboard ()
	{		
		if (ps.numOfPlayers == 2) 
		{
			if (player1Score > player2Score)
			{
				//ps.p1.transform.position.y = position1.y;
				//ps.p2.transform.position.y = position2.y;
			} 
			else
			{
				//ps.p2.transform.position.y = position1.y;
				//ps.p1.transform.position.y = position2.y;
			}
		}
		if (ps.numOfPlayers == 3)
		{
			
		}
		if (ps.numOfPlayers == 4) 
		{
			
		}


		ps.p1.transform.position = position1;
		//ps.p2.transform.position = posi;


	}

	// Update is called once per frame
	void Update () {
		
	}
}
