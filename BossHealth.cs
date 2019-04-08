using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Brandon Ruigrok
public class BossHealth : MonoBehaviour
{
    [SerializeField]
    public int Hp = 400;

    public BossBehavior bossDeath;
    public Action<int> BossTakingDamage;
    private bool canDie = true;

    private void Start()
    {
        bossDeath = GameObject.Find("Player").GetComponent<BossBehavior>();
    }

    public void TakeDamage(int damage)
    {
        Hp -= damage;

        if (BossTakingDamage != null)
        {
            BossTakingDamage(Hp);
        }
    }

    private void Update()
    {
        if (canDie == true)
        {
            if (Hp <= 0)
            {
                bossDeath.BossDied();
                canDie = false;
            }
        }
    }
}
