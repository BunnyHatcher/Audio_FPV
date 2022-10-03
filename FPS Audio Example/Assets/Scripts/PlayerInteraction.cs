using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Color _colorReticuleUse;
    [SerializeField] private Color _colorReticuleIdle;

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

        //ChangeCrossHairState(Color.red);
    }

    private void FindTarget()
    {
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, _maxDistance);

        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * _maxDistance, Color.magenta);
        
        if (hit.collider == null || hit.collider.gameObject.TryGetComponent(out IUsable _interface) == false )
        {
            _target = null;
            ChangeCrossHairState(_colorReticuleIdle);
        }

        else
        {
            _target = _interface;
            ChangeCrossHairState(_colorReticuleUse);


        }
    }

    private void UseTarget()
    {
        if (Input.GetButtonDown("Fire1")) _target.Use(); //if you put a single instruction into the same line, no need to put brackets
    }

    public void ChangeCrossHairState(Color color)
    {
        GameObject _crosshair = GameObject.Find("Crosshair");
        Image image = _crosshair.GetComponent<Image>();
        image.color = color;

    }







}
