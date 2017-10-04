using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerBar : MonoBehaviour {

    public KeyCode playerKey = KeyCode.A;

    bool down = true; //start moving up
    bool up = true; //start moving up

    float powerUp = 2.0f;
    float powerDown = 2.0f;
    float maxHeight = 100.0f;
    float minHeight = 2.0f;
    float maxLength = 2.5f;
    float minLength = 0.5f;

    public float currentHeight = 0.0f;
    public float currentRotation = 0;
    public GameObject power;
    public GameObject ball;
    public GameObject bat;
    public GameObject batParent;
    public GameObject imagePower;
    public GameObject playerManager;
	float prevSpeed = 0.0f;
    Rigidbody2D rigi;

	public enum ballState
	{
		Accelerating,
		Moving,
        StartRotating,
		Rotating,
		SpeedSelection,
        Hole,
		none
	}

    void Start ()
    {
        rigi = GetComponentInParent<Rigidbody2D>();
    }

	public ballState state = ballState.Rotating;

    // Update is called once per frame
    void Update () 
	{
        if (state == ballState.none)
        {
            return;
        }
        if (rigi.velocity.magnitude <= 0.001f &&
            !( 
            state == ballState.Rotating ||
            state == ballState.StartRotating ||
            state == ballState.SpeedSelection ||
            state == ballState.Hole
            ))
        {
            state = ballState.StartRotating;
        }
        else if(rigi.velocity.magnitude > 0.001f)
        {
            state = ballState.Moving;
        }
		bat.GetComponent<SpriteRenderer>().color = (new Color(1.0f , 1.0f, 1.0f));
		//transform.position = new Vector3(transform.position.x,  currentHeight, transform.position.z);
		switch (state) {
            case ballState.Moving:
                bat.SetActive(false);
                break;
            case ballState.StartRotating:
                bat.SetActive(true);
                batParent.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
                batParent.transform.Rotate(new Vector3(0.0f, 0.0f, -90.0f));
                currentRotation = 0.0f;
                state = ballState.Rotating;
            break;
            case ballState.Rotating:
			RotateShot ();
			if (Input.GetKeyDown (playerKey)) {
				state = ballState.SpeedSelection;
			}
			break;
		case ballState.SpeedSelection:
			MovePowerBar ();
            bat.transform.localScale = new Vector3(bat.transform.localScale.x, currentHeight / 100 * 2.0f + 1.0f, bat.transform.localScale.z);
                bat.GetComponent<SpriteRenderer>().color = (new Color((1.0f - (currentHeight) / 100), (currentHeight) / 100, 0.0f));
                //if (currentHeight < 50)
                //{
                //    bat.GetComponent<SpriteRenderer>().color = (new Color(1.0f, (currentHeight) / 50, 0.0f));
                //}
                //else
                //{
                //    bat.GetComponent<SpriteRenderer>().color = (new Color((1.0f - (currentHeight - 50) / 50), 1.0f, 0.0f));
                //}

                if (Input.GetKeyDown (playerKey)) {
				ball.GetComponent<BallController> ().ApplyForce(currentRotation, currentHeight/100);
				bat.SetActive (false);
                //addHit();
			}
			break;
		case ballState.Accelerating:
			
			if (prevSpeed > ball.GetComponent<Rigidbody2D> ().velocity.magnitude) {
				state = ballState.Moving;
			}
			prevSpeed = ball.GetComponent<Rigidbody2D> ().velocity.magnitude;
			break;
		case ballState.none:
			bat.SetActive (false);
			break;
        case ballState.Hole:
            bat.SetActive(false);
            break;
        }
	}

    void addHit()
    {
        if (ball.GetComponent<SpriteRenderer>().color == Color.blue)
        {
            playerManager.GetComponent<PlayerScript>().addScore(0, 1);
        }
		if (ball.GetComponent<SpriteRenderer>().color == Color.red)
        {
            playerManager.GetComponent<PlayerScript>().addScore(2, 1);
        }
		if (ball.GetComponent<SpriteRenderer>().color == Color.green)
        {
            playerManager.GetComponent<PlayerScript>().addScore(3, 1);
        }
		if (ball.GetComponent<SpriteRenderer>().color == Color.yellow)
        {
            playerManager.GetComponent<PlayerScript>().addScore(4, 1);
        }
    }

    void RotateShot()
    {
        //transform.localRotation.Set(transform.localRotation.x, transform.localRotation.y + 1, transform.localRotation.z, transform.localRotation.w);
        //Debug.Log("iiii");
        batParent.transform.position = ball.transform.position;
        batParent.transform.Rotate(new Vector3(0.0f, 0.0f, 2.0f));
        currentRotation += 2.0f;
        if (currentRotation > 360.0f)
        {
            currentRotation -= 360.0f;
        }
    }

    void MovePowerBar()
    {
        if (up)
        {
			currentHeight++;
			if (currentHeight > maxHeight)
            {
				up = false;
            }
        }
        else
        {
			currentHeight--;
			if (currentHeight < minHeight){
				up = true;
            }
        }
    }
}
