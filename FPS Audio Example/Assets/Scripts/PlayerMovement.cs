using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _normalSpeed;

    [SerializeField] private float _sprintSpeed;

    private float _speed;

    // instead of using rigidbody, we use a character controller
    CharacterController _characterController;

    AudioSource _audioSource;


    private void Awake()
    {
        //get the controller
        _characterController = GetComponent<CharacterController>();

        //get AudioSource
        _audioSource = gameObject.GetComponent<AudioSource>();
        
    }


    
    private void Update()
    {
        //Get Movement Input
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        //calculate direction with the help of both input values
        Vector3 direction = transform.right * horizontalInput + transform.forward * verticalInput;

        //Check if sprinting or not

        if (Input.GetButtonDown("Sprint"))
        {
            _speed = _sprintSpeed;
        }

        else
        {
            _speed = _normalSpeed;
        }

        // calculate movement by multiplying direction with speed (and deltatime to make movement frame-rate independent) 
        Vector3 move = direction * _speed * Time.deltaTime;

        //Create Movement function
        _characterController.Move(move);

        //set pitch to player speed
        _audioSource.pitch = _characterController.velocity.magnitude / _normalSpeed;



    }
}
