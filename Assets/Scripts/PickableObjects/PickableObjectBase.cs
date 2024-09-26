using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObjectBase : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        TriggerResponse(other);
    }

    public virtual void TriggerResponse(Collider _other)
    {
        if(_other.gameObject == PlayerMovement.Instance.gameObject)
        {
            Debug.Log("Pickup Detected");
        }
    }
}
