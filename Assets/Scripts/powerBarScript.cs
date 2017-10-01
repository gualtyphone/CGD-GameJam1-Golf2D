using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class powerBarScript : MonoBehaviour
{
    public float totalWidth = 256;
    public AudioSource powerSound;

    private float powerLevel;
    private bool isIncreasing = false;
    private bool ballIdle = false;

    private float powerBarSpeed = 2.5f;

    void Start()
    {
        GetComponent<Image>().transform.localScale = new Vector2(0.0f, 40.0f);
    }

   void Update()
    {
        if (!ballIdle && Input.GetButtonDown("Space"))
        {
            powerSound.Play();
            isIncreasing = true;
        }

        if (!ballIdle && Input.GetButtonUp("Space"))
        {
            isIncreasing = false;
            ApplyPower(powerLevel);
        }

        if (isIncreasing)
        {
            powerLevel += Time.deltaTime * powerBarSpeed;
            powerLevel = Mathf.Clamp(powerLevel, 0, totalWidth);
            GetComponent<Image>().transform.localScale = new Vector2(powerLevel, 40.0f);

            powerSound.pitch = powerLevel / 40;
        }
    }

    //IEnumerator Wait()
    //{
    //    yield return new WaitForSeconds(4); // or unitl ball idle
    //}

    void ApplyPower(float power)
    {
        ballIdle = true;

        //apply forces to ball (call function)
    
        GetComponent<Image>().transform.localScale = new Vector2(0.0f, 40.0f);
    }

}
