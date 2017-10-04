using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {

    [SerializeField]
    float speed;
    [SerializeField]
    AudioClip ballPot;
    [SerializeField]
    AudioSource source;

    PlayerScript players;


    int numPlayers = 0;

    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
        players = FindObjectOfType<PlayerScript>();
    }
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Ball")
        {
            if (other.GetComponentInChildren<powerBar>().state != powerBar.ballState.none)
            { 
                other.GetComponent<Rigidbody2D>().AddForce(((transform.position - other.transform.position) * (Time.deltaTime * speed)));
                if ((transform.position - other.transform.position).sqrMagnitude < (other.bounds.extents - GetComponent<Collider2D>().bounds.extents).sqrMagnitude)
                {
                    other.GetComponent<Collider2D>().enabled = false;
                    other.GetComponentInChildren<powerBar>().state = powerBar.ballState.none;
                    other.transform.position = transform.position;
                    other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    source.PlayOneShot(ballPot, 1f);

                    numPlayers++;
                    if (numPlayers == players.numOfPlayers)
                    {
                        FindObjectOfType<GameManager>().map++;

                        FindObjectOfType<GameManager>().needsUpdating = true;
                        Application.LoadLevel(2);
                    }

                }
            }
        }
        return;
        if (FindObjectOfType<GameManager>().map > FindObjectOfType<GameManager>().maps.Count)
        {
            Application.LoadLevel(3);
            return;
        }
    }
}
