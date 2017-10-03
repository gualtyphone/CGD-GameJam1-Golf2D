using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpaning : MonoBehaviour {
	
	PlayerScript ps;
	// Use this for initialization
	void Start () {
		ps = GameObject.FindObjectOfType<PlayerScript> ();
		spawnPlayers ();
	}
	
	// Update is called once per frame
	void Update () {
		
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
	public void spawnPlayers()
	{
		
		ps.players = new int[ps.numOfPlayers];

		for (int i = 0; i < ps.numOfPlayers; i++)
		{
			if (i == 0)
			{
				instantiatePlayer(Color.blue, KeyCode.A);
			}
			if (i == 1)
			{
				instantiatePlayer(Color.red, KeyCode.A);
			}
			if (i == 2)
			{
				instantiatePlayer(Color.green, KeyCode.A);
			}
			if (i == 3)
			{
				instantiatePlayer(Color.yellow, KeyCode.A);
			}
		}
	}
}
