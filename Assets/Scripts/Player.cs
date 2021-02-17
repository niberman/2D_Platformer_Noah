﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D myRigidbody;

    [SerializeField]

    private float movementSpeed;

    private bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        HandleMovement(horizontal);
    }

    public void HandleMovement(float horizontal)
    {
        myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y);
    }

    private void Flip(float horizontal)
    {
        if(facingRight == true && horizontal < 0)
        {
            facingRight = !facingRight;
            return;
        }
    }
    /*Update runs once per frame, fixed update runs as many times per frame as you want
     * fixed update works with the physics engine, so while using a rigidbody, you should use fixed
     */


}
