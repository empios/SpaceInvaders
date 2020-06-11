using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragFingerMove : MonoBehaviour
{
    private Vector3 touchPosition;
    private Rigidbody2D rb;
    private Vector3 direction;
    private float moveSpeed = 10f;

    public GameObject shot;
    public Transform spawnShot;
    public float fireRate;

    private float nextFire;
    // Use this for initialization
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    private void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            direction = (touchPosition - transform.position);
            rb.velocity = new Vector2(direction.x, direction.y) * moveSpeed;

            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(shot, spawnShot.position, spawnShot.rotation);
            }

            if (touch.phase == TouchPhase.Ended)
                rb.velocity = Vector2.zero;


        }
    }
}

