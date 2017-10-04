using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpaning : MonoBehaviour {
	
	PlayerScript ps;
	LeaderboadScript lbs;
	// Use this for initialization
	void Start () {
		//DontDestroyOnLoad (gameObject);
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
		

		for (int i = 0; i < ps.numOfPlayers; i++)
		{
			if (i == 0)
			{
				instantiatePlayer(Color.blue, ps.k1);
			}
			if (i == 1)
			{
				instantiatePlayer(Color.red, ps.k2);
			}
			if (i == 2)
			{
				instantiatePlayer(new Color(1.0f, 0.0f, 1.0f), ps.k3);
			}
			if (i == 3)
			{
				instantiatePlayer(Color.yellow, ps.k4);
			}
		}
	}
}
