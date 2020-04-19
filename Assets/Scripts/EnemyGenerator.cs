using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    private Transform enemyHolder;
    public GameObject enemy;
    private Vector3 newPosition;
    // Start is called before the first frame update
    void Start()
    {
        enemyHolder = GetComponent<Transform>();
        newPosition.Set(enemyHolder.position.x,enemyHolder.position.y, enemyHolder.position.z);
        InvokeRepeating("spawnEnemy", 2f, 2f);
        
    }

    void spawnEnemy()
    {
        
        GameObject spawned = Instantiate(enemy, newPosition, enemyHolder.rotation);
        spawned.transform.SetParent(gameObject.transform);
        float x = enemyHolder.transform.position.x + Random.Range(-6, 6);
        float y = enemyHolder.transform.position.y + Random.Range(0,2);
        float z = enemyHolder.transform.position.z;
        newPosition.Set(x, y, z);
    }
}
