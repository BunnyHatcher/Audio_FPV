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

    private void Update()
    {
                
        float mouseX = Input.GetAxis(“Mouse X”) * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(“Mouse Y”) * _mouseSensitivity * Time.deltaTime;

        float gamepadX = RightHorizontal * _padSensitivity.x * Time.deltaTime;
    }

}
