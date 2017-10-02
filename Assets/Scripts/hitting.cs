using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitting : MonoBehaviour
{

    // Use this for initialization
    public float power;
    public float rotation;
    public Rigidbody2D rb;
    public powerBar hit2;
    
   

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Hit()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        power = hit2.currentHeight;
        
        rb.AddForce(transform.forward * power * 1000);

    }
}

