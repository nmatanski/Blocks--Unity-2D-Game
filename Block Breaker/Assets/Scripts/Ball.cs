using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private Paddle paddle1;

    [SerializeField]
    private float xPush = 2f;

    [SerializeField]
    private float yPush = 15f;

    [SerializeField]
    private List<AudioClip> ballSounds;

    //state
    private Vector2 paddleToBallVector;
    private bool hasStarted = false;
    private bool isSizeChanged = false;
    
    //cached component refs
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnClick();
        }
    }

    private void LaunchOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            var clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Count)];
            audioSource.PlayOneShot(clip);
        }
    }

    public void ChangeSize()
    {
        if (!isSizeChanged)
        {
            transform.localScale /= 1.5f;
            GetComponent<CircleCollider2D>().radius /= 1.5f;
            isSizeChanged = true;
        }
        else
        {
            transform.localScale *= 1.5f;
            GetComponent<CircleCollider2D>().radius *= 1.5f;
            isSizeChanged = false;
        }
    }
}
