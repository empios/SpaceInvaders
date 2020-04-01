using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Transform spaceShip;
    public float speed;
    public float maxBound, minBound;


    // Start is called before the first frame update
    void Start()
    {
        spaceShip = GetComponent<Transform>();
         
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        if(spaceShip.position.x < minBound && h < 0)
        {
            h = 0;
        }
        else if(spaceShip.position.x>maxBound && h > 0)
        {
            h = 0;
        }

        spaceShip.position += Vector3.right * h * speed;
        
    }

    void Update()
    {
 
    }
}
