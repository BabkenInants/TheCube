using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Briliant : MonoBehaviour
{
    private Transform trans;

    private void Start()
    {
        trans = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        transform.Rotate(0f, 2f, 0f);
    }
}
