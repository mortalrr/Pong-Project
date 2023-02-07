using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    private Vector3 movement;
    [SerializeField]
    private int playerOneScore;
    [SerializeField]
    private int playerTwoScore;

    public Vector3 spawnPoint;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        this.movement = new Vector3(-9f, 10f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += movement * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;
        movement = Vector3.Reflect(movement, normal);

        if (collision.gameObject.CompareTag("Paddles"))
        {
            speed += 0.010f;
        }

        if (collision.gameObject.name == "RightWall")
        {
            playerTwoScore++;
            Debug.Log($"Player Two scored! The score is: {playerOneScore} - {playerTwoScore}" );
            transform.position = spawnPoint;
            this.movement = new Vector3(9f, 10f, 0f);
            speed = 0.025f;

            if (playerTwoScore > 10)
            {
                Debug.Log($"Game Over! Player Two Wins!" );
                playerOneScore = 0;
                playerTwoScore = 0;
            }
        }

        if (collision.gameObject.name == "LeftWall")
        {
            playerOneScore++;
            Debug.Log($"Player One scored! The score is: {playerOneScore} - {playerTwoScore}");
            transform.position = spawnPoint;
            this.movement = new Vector3(-9f, 10f, 0f);
            speed = 0.025f;
            
            if (playerOneScore > 10)
            {
                Debug.Log($"Game Over! Player One Wins!" );
                playerOneScore = 0;
                playerTwoScore = 0;
            }
            
        }

    }
}
