using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModelLookAtCamera : MonoBehaviour
{

    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, Camera.main.transform.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
}
