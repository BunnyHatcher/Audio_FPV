using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
        
    [SerializeField] private Vector2 _mouseSensitivity;
    [SerializeField] private Vector2 _padSensitivity;
    [SerializeField] private Vector2 _mouseYLimit;

    private float _horizontal;
    private float _vertical;

    public bool _cameraActive = false; // to activate camera when the player is really in the game and not before


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (_cameraActive)
        {
            //CAMERA VERTICAL ROTATION
            
            //get y-axis input
            float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * _mouseSensitivity.y;
                                
            //add input values to y-axis
            _vertical += mouseY;            

            // clamp the value for the up and down mouse movement
            _vertical = Mathf.Clamp(_vertical, _mouseYLimit.x, _mouseYLimit.y);

            // Camera Yaw
            Vector3 cameraAngles = Camera.main.transform.eulerAngles;
            Camera.main.transform.eulerAngles = new Vector3(_vertical, cameraAngles.y, cameraAngles.z);


            // PLAYER LATERAL ROTATION

            //get x-axis input
            float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * _mouseSensitivity.x;
            
            // add input values to x-axis
            _horizontal += mouseX;

            //Player rotation
            Vector3 playerAngles = transform.eulerAngles;
            transform.eulerAngles = new Vector3(playerAngles.x, _horizontal, playerAngles.z);


            //float gamePadX = RightHorizontal * _padSensitivity.x * Time.deltaTime;
            //float gamePadY = RightVertical * _padSensitivity.y * Time.deltaTime;

        }

        if (Input.GetButton("Fire1"))
        { _cameraActive = true; }
    }

}
