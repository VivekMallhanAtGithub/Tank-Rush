using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    private float distanceToplayer;
    public float enemyspeed;
    public Transform enemyTarget;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(player);
        distanceToplayer = Vector3.Distance(transform.position, enemyTarget.position);

        transform.position = transform.position + (transform.forward * enemyspeed * Time.deltaTime);

        Vector3 direction = enemyTarget.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}