using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTalker : MonoBehaviour, IUsable
{
    AudioSource _audioSource;
    [SerializeField] private AudioClip[] _audioClips;
    
    private void Awake()
    {
        PlayerInteraction playerInteraction = FindObjectOfType<PlayerInteraction>();

        _audioSource = GetComponentInChildren<AudioSource>();
    }

    public void Use()
    {
       _audioSource.PlayOneShot(_audioClips[Random.Range(0, _audioClips.Length)]);


    }
}
