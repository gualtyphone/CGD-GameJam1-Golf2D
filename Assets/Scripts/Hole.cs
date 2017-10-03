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

    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
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
            if (other.GetComponent<BallController>().enabled == true)
            { 
                other.GetComponent<Rigidbody2D>().AddForce(((transform.position - other.transform.position) * (Time.deltaTime * speed)));
                if ((transform.position - other.transform.position).sqrMagnitude < (other.bounds.extents - GetComponent<Collider2D>().bounds.extents).sqrMagnitude)
                {
                    other.GetComponent<BallController>().enabled = false;
                    other.transform.position = transform.position;
                    other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    source.PlayOneShot(ballPot, 1f);
                }
            }
        }
    }
}
