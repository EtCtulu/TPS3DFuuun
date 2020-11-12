using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Référence du Character Controller
    private CharacterController characterController;

    public Transform camera;

    // Référence de la moveSpeed
    [SerializeField]
    public float moveSpeed = 100;

    private void Awake()
    {
        // Attribution du character controller 
        characterController = GetComponent<CharacterController>();
    }


    void Update()
    {
        // Liaison des variables Horizontal et Verticales a l'axis
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        // Combinaison des deux dans une variable Movement
        var movement = new Vector3(horizontal, 0, vertical);

        // Attribution de Mvt au CC
        characterController.SimpleMove(movement * Time.deltaTime * moveSpeed);

        transform.rotation = camera.transform.rotation;
    }
}
