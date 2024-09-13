using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAndDamage : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health = 100f;
    public float damage1 = 30f;

    private PlayerMovement movementComponent;
    private PlayerUI uiComponent;

    private void Awake()
    {
        movementComponent = GetComponent<PlayerMovement>();
        if(movementComponent != null)
        {
            uiComponent = GetComponent<PlayerUI>();
        }
        else
        {
            
        }
    }

    private void Start()
    {
             
    }

    public void AcceptDamage()
    {
        health -= damage1;

        if (movementComponent != null)
        {
            movementComponent.PlayerMovementDamageTakenSignal(damage1);
        }

        if (uiComponent != null)
        {
            uiComponent.UpdateHealthBar(GetHealthRatio());
        }

        if (health < 0)
        {
            Death();
        }
    }

    public void AcceptDamage(float incomingDamage)
    {
        health -= incomingDamage;

        if (movementComponent != null)
        {
            movementComponent.PlayerMovementDamageTakenSignal(incomingDamage);
        }

        if(uiComponent!=null)
        {
            uiComponent.UpdateHealthBar(GetHealthRatio());
        }

        if(health < 0)
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
