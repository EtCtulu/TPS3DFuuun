using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{

    // Variables Vie Shield
    private int _hp = 100;
    private int _shield = 0;
    
    // Le gunpoint
    public Transform gunPoint;

    // Les usables
    public GameObject poids;
    public GameObject mine;

    [Range(0, 1000)] public float power = 30;
    [Range(0, 1000)] public float angle = 70;
    

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
        // Reset de l'anim de marche si inactif
        anim.SetBool("WalkT", false);

        // Player Mvt
        if (Input.GetKey(KeyCode.Z))
        {
            transform.Translate(Vector3.forward * ((moveSpeed) * Time.deltaTime));
            anim.SetBool("WalkT", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * ((moveSpeedNegative) * Time.deltaTime));
            anim.SetBool("WalkT", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * ((moveSpeed) * Time.deltaTime));
            anim.SetBool("WalkT", true);
        }
            if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector3.right * ((moveSpeedNegative) * Time.deltaTime));
            anim.SetBool("WalkT", true);
        }



        // Player Shot
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject alter = Instantiate(poids, gunPoint);
            Vector3 projection = new Vector3(alter.transform.position.x,  Mathf.Abs(power * Mathf.Sin(angle)), Mathf.Abs(power * Mathf.Tan(angle)));
            alter.GetComponent<Rigidbody>().AddForce(projection, ForceMode.Force);
            
        }

        //Player Mine1
        if (Input.GetKeyDown(KeyCode.G))
        {
            GameObject themine = Instantiate(mine, gunPoint);
            themine.transform.parent = null;
        }

            // Le quaternion euler est comme un .rotation sauf que l'on peut changer indépendament les valeurs xyz
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, Camera.main.transform.eulerAngles.y, transform.rotation.eulerAngles.z);

            
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Attack"))
        {
            var attack = 20;
                
            if (_shield >= 15)
            {
                attack = attack - 5;
                _shield = _shield - 15;
            }

            _hp = _hp - attack;
            Debug.Log("Vie : " + _hp );
            if (_hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
