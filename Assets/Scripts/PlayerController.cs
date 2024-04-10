using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    private float Speed;

    void Update()
    {
        //Debug.Log(Input.acceleration);
        if (PlayerPrefs.GetInt("DisableMovement") == 1)
        {
            Speed = 0f;
        }

        if (PlayerPrefs.GetInt("DisableMovement") == 0)
        {
            Speed = 500f;
        }

        if (Math.Abs(Input.acceleration.y) >= Math.Abs(Input.acceleration.x))
        {
            rb.AddForce(Input.acceleration.y * Speed * Time.deltaTime, 0f, 0f);
        }

        if (Math.Abs(Input.acceleration.y) < Math.Abs(Input.acceleration.x))
        {
            rb.AddForce(0f, 0f, -Input.acceleration.x * Speed * Time.deltaTime);
        }
    }
}