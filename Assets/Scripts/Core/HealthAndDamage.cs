using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAndDamage : MonoBehaviour
{
    public float health = 100f;
    public float damage1 = 30f;
    public float damage2 = 50f;

    public void AcceptDamage(float incomingDamage)
    {
        health = health - incomingDamage;

        if(health<0)
        {
            Death();
        }
    }

    public void Death()
    {

    }
}
