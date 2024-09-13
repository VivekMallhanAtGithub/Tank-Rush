using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ET1_Attack : MonoBehaviour
{
    EnemyBase baseEnemyScript;
    private bool canAttack;

    private void Awake()
    {
        baseEnemyScript = GetComponent<EnemyBase>();
    }
    void Start()
    {
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.Instance == null)
        {
            return;
        }

        if(canAttack==false)
        {
            return;
        }

        if(baseEnemyScript.distanceToplayer < 0.3f)
        {
            PlayerMovement.Instance.GetComponent<HealthAndDamage>().AcceptDamage();
        }

        canAttack = false;
        StartCoroutine(AttackCoolDown(1));
    }

    IEnumerator AttackCoolDown(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        canAttack = true;
    }
}
