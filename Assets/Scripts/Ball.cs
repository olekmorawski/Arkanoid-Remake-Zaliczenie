﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Platform paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballsounds;

    Vector2 paddleToBallVector;
    bool hasStarted = false;

    AudioSource myAudioSource;

    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPlatform();
            LaunchBallOnSpace();
        }
    }

    private void LockBallToPlatform()
    {
        Vector2 paddlepos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlepos + paddleToBallVector;
    }

    private void LaunchBallOnSpace()
    {
        if (Input.GetKeyDown("space"))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(hasStarted)
        {
            AudioClip clip = ballsounds[UnityEngine.Random.Range(0, ballsounds.Length)];
            myAudioSource.PlayOneShot(clip);
        }
    }
}
