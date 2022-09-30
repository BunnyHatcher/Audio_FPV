using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float _maxDistance = 100f;

    [SerializeField] private IUsable _target;

    //public Camera camera;

    RaycastHit hit;

    private void Start()
    {
        

        
    }



    private void Update()
    {
        FindTarget();

        UseTarget();

        ChangeCrossHairState();
    }

    private void FindTarget()
    {
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, _maxDistance);

        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * _maxDistance, Color.magenta);
        
        if (hit.collider == null || hit.collider.gameObject.TryGetComponent(out IUsable _interface) == false )
        {
            _target = null;
        }

        else
        {
            _target = _interface;

            
        }
    }

    private void UseTarget()
    {
        if (Input.GetButtonDown("Fire1")) _target.Use(); //if you put a single instruction into the same line, noi need to put brackets
    }

    private void ChangeCrossHairState()
    {

    }







}
