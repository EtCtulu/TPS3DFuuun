using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMoving : MonoBehaviour
{

    private Rigidbody _rb;


    private void Start()
    {
        _rb = transform.GetComponent<Rigidbody>();
        transform.parent = null;
    }

    void Update()
    {
        _rb.AddForce(transform.forward * 40);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
