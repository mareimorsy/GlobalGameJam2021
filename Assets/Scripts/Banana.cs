﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float thrust = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
                rb2D.AddForce(Vector2.left * thrust);
        // rb2D = gameObject.AddComponent<Rigidbody2D>();
        // transform.position = new Vector3(0.0f, -2.0f, 0.0f);

    }

    // Update is called once per frame
    void Update()
    {
                // rb2D.AddForce(transform.up * thrust);
    }

    void FixedUpdate()
    {
        // rb2D.AddForce(transform.down * thrust);

    }
}