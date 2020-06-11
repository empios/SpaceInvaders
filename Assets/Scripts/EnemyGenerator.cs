using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    private Transform enemyHolder;
    public GameObject enemy;
    public bool isCampaign;
    public float border;
    private Vector3 newPosition;
    private int enemyCounter;
    // Start is called before the first frame update
    void Start()
    {
        enemyCounter = 0;
        enemyHolder = GetComponent<Transform>();
        float x = Random.Range(-border, border);
        float y =3;
        float z = enemyHolder.transform.position.z;
        newPosition.Set(x, y, z);
        if(!isCampaign) InvokeRepeating("spawnEnemy", 1f, 1f);
        
    }

    void spawnEnemy()
    {
        float x = Random.Range(-border, border);
        float y = 3;
        float z = enemyHolder.transform.position.z;
        newPosition.Set(x, y, z);
        GameObject spawned = Instantiate(enemy, newPosition, enemyHolder.rotation);
        spawned.transform.SetParent(gameObject.transform);
        if(enemyCounter%10==0) InvokeRepeating("spawnEnemy", 1f, 1f);
        enemyCounter++;
    }
}
