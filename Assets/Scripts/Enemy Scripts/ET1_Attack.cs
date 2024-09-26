using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ET1_Attack : MonoBehaviour
{
    private EnemyBase baseEnemyScript;
    public float attackCooldown;
    public bool canAttack;
    float timerValue;

    private void Awake()
    {
        baseEnemyScript = GetComponent<EnemyBase>();
    }

    private void FixedUpdate()
    {
        if (canAttack == false)
        {
            timerValue += 0.02f;
            if (timerValue > attackCooldown)
            {
                timerValue = 0f;
                canAttack = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (baseEnemyScript.distanceToplayer < 0.3f && canAttack == true)
        {
            float outGoingDamage = GetComponent<HealthAndDamage>().damage1;
            if (PlayerMovement.Instance != null)
            {
                PlayerMovement.Instance.gameObject.GetComponent<HealthAndDamage>().AcceptDamage(outGoingDamage);
                canAttack = false;
                baseEnemyScript.enemyspeed = 1;
            }

        }
    }

}