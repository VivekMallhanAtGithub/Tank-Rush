using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAndDamage : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health = 100f;
    public float damage1 = 30f;

    delegate void DamageTakenDelegate(float _incomingDamage);

    DamageTakenDelegate delegate_DamageTaken;

    private void Start()
    {
        delegate_DamageTaken = AcceptDamage;
    }

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
        Debug.Log("Health less than 0. Destroying Game Object");
        Destroy(gameObject);
    }
    
    public float GetHealthRatio()
    {
        return health / maxHealth;
    }

    
}
