using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHP : MonoBehaviour
{

    public static int Hp;

    public static GameObject boss;

    public void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss");
        Hp = 30;
    }

    public static void ChangeHp()
    {
        if (--Hp <= 0) 
        {
            Destroy(boss);
        }
    }
}
