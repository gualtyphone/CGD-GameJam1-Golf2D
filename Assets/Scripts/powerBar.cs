using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerBar : MonoBehaviour {
    
        bool up = true; //start moving up
        bool down = false;
        public bool Pstopped = false;
        public bool Rstopped = true;

        float powerUp = 2.0f;
        float powerDown = 2.0f;
        float maxHeight = 100;
        float minHeight = 0;
        public float currentHeight = 0;
        public float currentRotation = 0;
        public GameObject power;
        public GameObject ball;
        public GameObject bat;
        public GameObject batParent;

    // Update is called once per frame
    void Update () {
        if (!Pstopped)
        {
            MovePowerBar();
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Pstopped = true;
                Rstopped = false;
                //RotateShot();
                //currentHeight = power.transform.position.y;  
            }
        }
        else if (!Rstopped)
        {
            RotateShot();
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Rstopped = true;
                //RotateShot();
                currentHeight = power.transform.position.y;
                //currentRotation = rotation.transform.rotation.y;
                Debug.Log(currentRotation);
                ball.GetComponent<RollingBehaviour>().ApplyForce(currentRotation, 1.0f);
                Destroy(bat);

            }
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
            transform.Translate(Vector2.up * powerUp);  //move bar up
            if (transform.position.y > maxHeight)
            {
                up = false;
                down = true;
               
            }
            
        }
        else if (!up)
        {
            transform.Translate(Vector2.up * -powerDown);   //move bar down
            if (transform.position.y < minHeight)
            {
                down = false;
                up = true;
            }
        }
    }
}
