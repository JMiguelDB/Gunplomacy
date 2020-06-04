﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;

    //[!] Android ##########
    public bool enAndroid = false;
    [SerializeField]
    JoystickControl joystickControl;
    //[!] End of Android ##########

    float moveHorizontal;
    float moveVertical;

    private Rigidbody2D rb;
    private Animator animator;
    private Vector3 m_velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        if (enAndroid == true)
        {

            moveHorizontal = joystickControl.Input.x * speed;
            moveVertical = joystickControl.Input.z * speed;
            print("moveHorizontal" + moveHorizontal);
        }
        else
        {
            print("2");
            moveHorizontal = Input.GetAxisRaw("Horizontal") * speed;
            moveVertical = Input.GetAxisRaw("Vertical") * speed;
        }
        animator.SetBool("Andando", (moveHorizontal != 0) || (moveVertical != 0));

        Vector3 targetVelocity = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_velocity, m_MovementSmoothing);
    }
}