using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdScript : MonoBehaviour
{
    private Rigidbody2D birdRB;
    private float goUpSpeed;
    // Start is called before the first frame update
    void Start()
    {
        birdRB = GetComponent<Rigidbody2D>(); 
        goUpSpeed = 18.0f;
        birdRB.gravityScale = 5; 
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.me.CanFly)
        {
            BirdFly(); 
        }
        
        if(gameObject.transform.position.y < -22)
        {
            Destroy(gameObject);
        }
    }

    private void BirdFly()
    {
        if (Input.GetMouseButtonDown(0))
        {
            birdRB.velocity = Vector2.up * goUpSpeed; 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Game Over");
        GameManager.me.GameOver();
    }
}
