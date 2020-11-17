using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightAddForce : MonoBehaviour
{

    private Rigidbody rb;
    public float power = -8000;
    public float upPower = -99000;

    private void Start()
    {
        transform.parent = null;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.up * upPower, ForceMode.Impulse);
        rb.AddForce(transform.forward * power, ForceMode.Impulse);
        
        
    }


}
