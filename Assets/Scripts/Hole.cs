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
        source.PlayOneShot(ballPot, 1f);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (Vector3.Distance(transform.position, other.transform.position) < other.bounds.extents.magnitude)
        other.GetComponent<Rigidbody2D>().AddForce((transform.position - other.transform.position) * Time.deltaTime * speed);
        if ((transform.position - other.transform.position).sqrMagnitude < (other.bounds.extents - GetComponent<Collider2D>().bounds.extents).sqrMagnitude)
        {
            Debug.Log("Hole");
			other.GetComponent<BallController>().enabled = false;
            other.transform.position = transform.position;
            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
