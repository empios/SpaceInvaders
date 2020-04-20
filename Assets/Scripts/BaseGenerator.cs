using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGenerator : MonoBehaviour
{   
    private Transform baseHolder;
    public GameObject basePrefab;
    private Vector3 newPosition;
    // Start is called before the first frame update
    void Start()
    {
    baseHolder = GetComponent<Transform>();
    newPosition.Set(baseHolder.position.x, baseHolder.position.y, baseHolder.position.z);
    InvokeRepeating("spawnBase", 4f, 4f);
    }

    void spawnBase()
    {
        float x = Random.Range(-7, 7);
        float y = Random.Range(-3,-2);
        float z = baseHolder.transform.position.z;
        newPosition.Set(x, y, z);
        GameObject spawned = Instantiate(basePrefab, newPosition, baseHolder.rotation);
        spawned.transform.SetParent(gameObject.transform);
       
    }
}
