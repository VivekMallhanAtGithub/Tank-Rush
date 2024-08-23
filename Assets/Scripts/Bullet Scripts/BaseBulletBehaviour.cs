using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBulletBehaviour : MonoBehaviour
{
    public float bulletSpeed = 50f;
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
    void Update()
    {
        transform.Translate(transform.forward * bulletSpeed * Time.deltaTime);
    }
}
