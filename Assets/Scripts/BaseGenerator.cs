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

        GameObject spawned = Instantiate(basePrefab, baseHolder.position, baseHolder.rotation);
        spawned.transform.SetParent(gameObject.transform);
        float x = baseHolder.transform.position.x + Random.Range(-7, 7);
        float y = baseHolder.transform.position.y + Random.Range(-1, 1);
        float z = baseHolder.transform.position.z;
        newPosition.Set(x, y, z);
    }
}
