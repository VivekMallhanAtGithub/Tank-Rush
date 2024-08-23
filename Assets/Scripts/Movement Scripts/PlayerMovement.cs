using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    Vector2 movementValues = Vector2.zero;
    Vector2 LookingValues = Vector2.zero;
    public float frameDistance = 1f;
    public float mass = 20;
    public float lookSpeed = 2f;
    public float bulletFrequency = 1f;
    public float bulletTimer = 0f;
    public GameObject bulletPrefab;

    public void IAAccelerate(InputAction.CallbackContext context)
    {
        movementValues = context.ReadValue<Vector2>();

    }
    public void IAShoot(InputAction.CallbackContext context)
    {
        Shoot();
    }

    public void IALooking(InputAction.CallbackContext context)
    {
        LookingValues = context.ReadValue<Vector2>();

        transform.Rotate(transform.up, LookingValues.x * Time.deltaTime * lookSpeed);
    }
    private void FixedUpdate()
    {
       
    }

    // Start is called before the first frame update 
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movementValues.x * frameDistance * Time.deltaTime, 0, movementValues.y * frameDistance * Time.deltaTime);
        //rbBody.AddForce(movementValues.x * frameDistance * Time.deltaTime, 0, movementValues.y * frameDistance * Time.deltaTime);
        //rbBody.mass = mass;

    }
    public void Shoot()
    {
        Instantiate(bulletPrefab, transform.position + transform.forward, Quaternion.identity);
    }

}
