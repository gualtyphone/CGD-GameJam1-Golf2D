using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBehaviour : MonoBehaviour {
    Vector3 pos;
    Rigidbody2D rigi;
    Vector2 vel;
    public HeatMap heatmap; 
    public float degrees = 20.0f;
    public float magnitude = 1.0f; 
    float[] surroundArea = new float[9];
    float offset = -90.0f; 
    void Start ()
    {
        //pos = new Vector3(0, 0, 0);
        pos = this.transform.position;
        rigi = GetComponent<Rigidbody2D>();
        vel = rigi.velocity;
        ApplyForce((360 - degrees) - offset, magnitude);
    }

    // Update is called once per frame
    void Update ()
    {
        surroundArea = heatmap.getPixelsAtPosition(pos);
        //Debug.Log(surroundArea[0]);
        pos = this.transform.position;
        Vector2 uForce = new Vector2(0, (surroundArea[4] - surroundArea[1]));
        Vector2 dForce = new Vector2(0, (surroundArea[4] - surroundArea[7]) * -1);
        Vector2 lForce = new Vector2((surroundArea[4] - surroundArea[3]), 0);
        Vector2 rForce = new Vector2((surroundArea[4] - surroundArea[5]) * -1, 0);
        Vector2 urForce = new Vector2((surroundArea[4] - surroundArea[2]) * -0.5f, (surroundArea[4] - surroundArea[2]) * 0.5f);
        Vector2 ulForce = new Vector2((surroundArea[4] - surroundArea[0]) * 0.5f, (surroundArea[4] - surroundArea[0]) * 0.5f);
        Vector2 drForce = new Vector2((surroundArea[4] - surroundArea[8]) * -0.5f, (surroundArea[4] - surroundArea[8]) * -0.5f);
        Vector2 dlForce = new Vector2((surroundArea[4] - surroundArea[6]) * 0.5f, (surroundArea[4] - surroundArea[6]) * -0.5f);
        
        vel = uForce + dForce + lForce + rForce + urForce + ulForce + drForce + dlForce;
        //Debug.Log(vel);
        //Vector3 vel3 = new Vector3(vel.x, 0.0f, vel.y);
        rigi.AddForce(vel);
    }
    //Direction 0-360 degrees 
    void ApplyForce(float degree, float magnitude)
    {
        Vector2 direction = (Vector2)(Quaternion.Euler(0, 0, degree) * Vector2.right);
        rigi.AddForce(direction * magnitude); 
    }
}
