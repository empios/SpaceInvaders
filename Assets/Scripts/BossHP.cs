using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHP : MonoBehaviour
{

    public static int Hp = 5;

    public static GameObject boss;

    public void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss");
    }

    public static void ChangeHp()
    {
        Debug.Log(Hp);
        if (--Hp <= 0) 
        {
            Destroy(boss);
            
        }
    }
}
