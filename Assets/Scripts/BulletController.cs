﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    private Transform bullet;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Transform>();


    }

    void FixedUpdate()
    {
        bullet.position += Vector3.up * speed;

        if(bullet.position.y >= 7.5)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            PlayerScore.playerScore += 5;
        }
        else if(collision.tag == "Base")
        {
            Destroy(gameObject);
        }
    }
}
