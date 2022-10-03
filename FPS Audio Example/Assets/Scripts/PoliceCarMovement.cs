using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCarMovement : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _maxDistance;
    [SerializeField] float _minDistance;

    private bool _isFacingNorth = true;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        PushForward();
    }

    private void Update()
    {
        Debug.Log(gameObject.transform.localPosition.z);
        
        if (_isFacingNorth)
        {
            if (gameObject.transform.localPosition.z >= _maxDistance)
            {
                UTurn();
            }
        }
        
        else
        {
            if (gameObject.transform.localPosition.z <= _minDistance)
            {
                UTurn();
            }
        }


    }


    //----------------------------METHODS-------------------------------------------------------------------------

    private void PushForward()
    {
        _rigidbody.velocity = transform.forward * _speed;
    }

    private void UTurn()
    {
        // inverse our transform's forward (Z-axis)
        transform.forward = -transform.forward;

        // inverse the value of the direction variable (0 = go forward; 1= go backward)
        _isFacingNorth = !_isFacingNorth;
        
        // We turn around
        PushForward();

    }

}
