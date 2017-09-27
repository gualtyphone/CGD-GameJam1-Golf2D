﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBehaviour : MonoBehaviour {
    Vector3 pos;
    Rigidbody2D rigi;
    Vector2 vel; 
    float[] surroundArea = new float[9] { 0.0f, 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f };
    void Start ()
    {
        pos = new Vector3(0, 0, 0);
        this.transform.position = pos;
        vel = rigi.velocity; 
    }

    // Update is called once per frame
    void Update ()
    {
        surroundArea = getPosition(pos); 
        pos = this.transform.position;
        //get values from Gual 
        Vector2 uForce = new Vector2(0, (surroundArea[4] - surroundArea[1]));
        Vector2 dForce = new Vector2(0, (surroundArea[4] - surroundArea[7])*-1);
        Vector2 lForce = new Vector2((surroundArea[4] - surroundArea[3]), 0);
        Vector2 rForce = new Vector2((surroundArea[4] - surroundArea[5])*-1, 0);
        Vector2 urForce = new Vector2((surroundArea[4] - surroundArea[2]) * -0.5f, (surroundArea[4] - surroundArea[2]) * 0.5f);
        Vector2 ulForce = new Vector2((surroundArea[4] - surroundArea[0]) * 0.5f, (surroundArea[4] - surroundArea[0]) * 0.5f);
        Vector2 drForce = new Vector2((surroundArea[4] - surroundArea[8]) * -0.5f, (surroundArea[4] - surroundArea[8]) * -0.5f);
        Vector2 dlForce = new Vector2((surroundArea[4] - surroundArea[6]) * 0.5f, (surroundArea[4] - surroundArea[6]) * -0.5f);
        vel = uForce + dForce + lForce + rForce + urForce + ulForce + drForce + dlForce;
        pos = vel * Time.deltaTime; 
    }
}