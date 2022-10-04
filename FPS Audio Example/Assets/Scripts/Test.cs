using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour, IUsable
{
    PlayerInteraction playerInteraction;

    private void Start()
    {
        playerInteraction = FindObjectOfType<PlayerInteraction>();
            
    }

    public void Use()
    {
        Debug.Log("Touchdown!");
        playerInteraction.ChangeCrossHairState(Color.magenta);
    }
}
