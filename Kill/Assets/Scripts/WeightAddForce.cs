using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightAddForce : MonoBehaviour
{

    private Rigidbody rb;
    public float power = 50;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.up * power, ForceMode.Impulse);
        rb.AddForce(transform.forward * power, ForceMode.Impulse);
    }
}
