using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBulletBehaviour : MonoBehaviour
{
    public float bulletSpeed = 50f;
    public Rigidbody bulletRigidBody;
    private Vector3 direction;
    public float bulletDamage = 5f;


    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<HealthAndDamage>().AcceptDamage(bulletDamage);
        Destroy(gameObject);
    }
    private void FixedUpdate()
    {
        bulletRigidBody.AddForce(direction * 1f);
        RaycastHit rayHit;
        if (Physics.Raycast(transform.position, bulletRigidBody.velocity.normalized,out rayHit, bulletRigidBody.velocity.magnitude* 0.02f))
        {
            rayHit.transform.gameObject.GetComponent<HealthAndDamage>().AcceptDamage(bulletDamage);
        }

        Debug.DrawLine(transform.position, transform.position + bulletRigidBody.velocity);
    }

    public void SetBulletDirection(Vector3 desiredDirection)
    {
        direction = desiredDirection;
    }
}
