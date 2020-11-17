using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    public CinemachineFreeLook camera;

    // Référence du Character Controller
    private CharacterController characterController;


    // Référence de la moveSpeed
    public float moveSpeed = 5;
    public float moveSpeedNegative = -5;

    public Animator anim;

    private void Awake()
    {
        // Attribution du character controller 
        characterController = GetComponent<CharacterController>();
    }


    void Update()
    {
        anim.SetBool("WalkT", false);
        // Player Mvt
        if (Input.GetKey(KeyCode.Z))
        {
            transform.Translate(Vector3.forward * (moveSpeed) * Time.deltaTime);
            anim.SetBool("WalkT", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * (moveSpeedNegative) * Time.deltaTime);
            anim.SetBool("WalkT", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * (moveSpeed) * Time.deltaTime);
            anim.SetBool("WalkT", true);
        }
            if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector3.right * (moveSpeedNegative) * Time.deltaTime);
            anim.SetBool("WalkT", true);
        }



            // Player Shot


            // Le quaternion euler est comme un .rotation sauf que l'on peut changer indépendament les valeurs xyz
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, Camera.main.transform.eulerAngles.y, transform.rotation.eulerAngles.z);

    }
}
