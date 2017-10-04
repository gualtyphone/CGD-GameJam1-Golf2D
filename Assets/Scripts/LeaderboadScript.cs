using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboadScript : MonoBehaviour {

	public GameObject position1;
	public GameObject position2;
	public GameObject position3;
	public GameObject position4;

	private int player1Score = 0;
	private int player2Score = 0;
	private int player3Score = 0;
	private int player4Score = 0;

	PlayerScript ps;

	public GameObject button;

	public void NextLevel()
	{
		if (FindObjectOfType<GameManager> ().map >= FindObjectOfType<GameManager> ().maps.Count) {
			Application.Quit();
		} else {
			FindObjectOfType<GameManager> ().needsUpdating = true;
			Application.LoadLevel (1);
		}
	}

	// Use this for initialization
	void Start () {
		ps = GameObject.FindObjectOfType<PlayerScript> ();
		if (FindObjectOfType<GameManager> ().map >= FindObjectOfType<GameManager> ().maps.Count) {
			button.GetComponentInChildren<Text> ().text = "Quit";
		} else {
			button.GetComponentInChildren<Text> ().text = "Next Level";
		}
	}

	// Update is called once per frame
	void Update () 
	{
		if (ps.numOfPlayers == 1)
		{
			player1Score = ps.getLeaderboard() [0];
		}
		else if (ps.numOfPlayers == 2) 
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
		if (ps.numOfPlayers == 1)
		{
			position1.SetActive (true);
			position2.SetActive (false);
			position3.SetActive (false);
			position4.SetActive (false);

			position1.GetComponentInChildren<Text> ().text = player1Score.ToString();
		}
		else if (ps.numOfPlayers == 2) 
		{
			position1.SetActive (true);
			position2.SetActive (true);
			position3.SetActive (false);
			position4.SetActive (false);

			position1.GetComponentInChildren<Text> ().text = player1Score.ToString();
			position2.GetComponentInChildren<Text> ().text = player2Score.ToString();

		}
		else if (ps.numOfPlayers == 3)
		{
			position1.SetActive (true);
			position2.SetActive (true);
			position3.SetActive (true);
			position4.SetActive (false);

			position1.GetComponentInChildren<Text> ().text = player1Score.ToString();
			position2.GetComponentInChildren<Text> ().text = player2Score.ToString();
			position3.GetComponentInChildren<Text> ().text = player3Score.ToString();

		}
		if (ps.numOfPlayers == 4) 
		{
			position1.SetActive (true);
			position2.SetActive (true);
			position3.SetActive (true);
			position4.SetActive (true);

			position1.GetComponentInChildren<Text> ().text = player1Score.ToString();
			position2.GetComponentInChildren<Text> ().text = player2Score.ToString();
			position3.GetComponentInChildren<Text> ().text = player3Score.ToString();
			position4.GetComponentInChildren<Text> ().text = player4Score.ToString();
		}
		//ps.p1.transform.position = position1;
		//ps.p2.transform.position = posi;
	}


}
