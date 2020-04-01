using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
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
        bullet.position += Vector3.up * -speed;

        if (bullet.position.y <= -10)
            Destroy(bullet.gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
     if(collision.tag == "Player")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            GameOver.isPlayerDead = true;
        }   

     else if (collision.tag == "Base")
        {
            GameObject playerBase = collision.gameObject;
            BaseHealth baseHealth = playerBase.GetComponent<BaseHealth>();
            baseHealth.health -= 1;
            Destroy(gameObject);
        }
    }
}
