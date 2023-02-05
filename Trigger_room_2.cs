using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_room_2 : MonoBehaviour
{
    

    
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject fire;
   
    // Wenn der Trigger betreten wird 
    private void OnTriggerEnter(Collider other)
    {
        // Spielt Animation
        door.GetComponent<PlayAnim>().PlayAnimation();
        // Particle werden aus gestellt 
        fire.GetComponent<ParticleOnOff>().SwitchOnOff();
        // sound abgespielt
        fire.GetComponent<AudioSource>().Play();
        
        Destroy(gameObject);
    }
}
