using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    // instead of using rigidbody, we use a character controller
    CharacterController _characterController; 


    private void Awake()
    {
        //get the controller
        _characterController = GetComponent<CharacterController>();
        
    }


    private void Update()
    {
        //Get Movement Input
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        //calculate direction with the help of both input values
        Vector3 direction = transform.right * horizontalInput + transform.forward * verticalInput;

        // calculate movement by multiplying direction with speed (and deltatime to make movement frame-rate independent) 
        Vector3 move = direction * _speed * Time.deltaTime;

        //Create Movement function
        _characterController.Move(move);


    }
}
