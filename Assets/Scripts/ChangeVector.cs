using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVector : MonoBehaviour
{
    public GameObject enemy;
    public float speed;
    public bool isMovingRight;

    // Update is called once per frame
    void FixedUpdate()
    {
        //check is enemy in bounds
        if (enemy.transform.position.x > 9 && isMovingRight) isMovingRight = false;
        else if (enemy.transform.position.x < -9 && !isMovingRight) isMovingRight = true;

        //right 
        if (isMovingRight)
        {
            Vector3 newPosition = new Vector3(enemy.transform.position.x + speed, enemy.transform.position.y, enemy.transform.position.z);
            enemy.transform.position = newPosition;
        }
        //change vector
        //left
        else if(!isMovingRight)
        {
            Vector3 newPosition = new Vector3(enemy.transform.position.x - speed, enemy.transform.position.y-0.025f, enemy.transform.position.z);
            enemy.transform.position = newPosition;
        }
        if (enemy.transform.position.y <= -3)
        {
            GameOver.isPlayerDead = true;
            Time.timeScale = 0;

        }
    }
    public void setSpeed(float speed)
    {
        this.speed = speed;
    }
}
