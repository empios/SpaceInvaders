using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{

    private Transform enemyHolder;
    public float speed;

    public GameObject shot;
    public Text winText;
    public float fireRate = 0.997f;

    // Start is called before the first frame update
    void Start()
    {
        winText.enabled = false;
        InvokeRepeating("changeSpeed", 0.1f, 0.3f);
        enemyHolder = GetComponent<Transform>();
    }
    void changeSpeed()
    {
        this.speed += 0.002f;
        foreach(Transform enemy in enemyHolder)
        {
            if (Random.value > fireRate)
            {
                Instantiate(shot, enemy.position, enemy.rotation);
            }
            enemy.GetComponent<ChangeVector>().setSpeed(this.speed);
        }

        if(enemyHolder.childCount == 1)
        {
            CancelInvoke();
            InvokeRepeating("changeSpeed", 0.1f, 0.25f);
        }

        if(enemyHolder.childCount == 0)
        {
            winText.enabled = true;
            SceneLoader sceneLoader = new SceneLoader();
            sceneLoader.loadNextScene();
        }
    }
}
