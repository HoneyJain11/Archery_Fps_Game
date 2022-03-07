using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootForce : MonoBehaviour
{
    Rigidbody arrowRb;
    float arrowForce =300;

    private void Start()
    {
        arrowRb = GetComponent<Rigidbody>();
        arrowRb.velocity = Vector3.zero;

    }

    private void Update()
    { 
        ShootArrow();
    }

    private void ShootArrow()
    {
        arrowRb.AddRelativeForce(Vector3.right * arrowForce);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            return;
        StuckArrow();
    }

    private void StuckArrow()
    {
        arrowForce = 0;
        arrowRb.isKinematic = true;
        transform.localScale = transform.localScale + new Vector3(1, 1, 1);
    }

}
