using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleOnOff : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] parts;
    [SerializeField] private bool isWorking;
    [SerializeField] private int neededActions;

    private int count;

    private void Start()
    {
        //falls es nicht fuktioniert wird es ausgeschaltet   
        if (!isWorking)
        {
            for (int i = 0; i < neededActions; i++)
            {
                TurnOffCounter();
            }
            
        }
        
    }

    // funktionen zum zählen der Aktionen
    public void TurnOffCounter()
    {
        
        count++;
        // falls genügnd Aktionen ausgeführt wurden
        if (neededActions == count)
        {
            // werden alle im Array befindenen partikel ausgestellt
            foreach (var part in parts)
            {
                part.enableEmission = false;
                // und die Musik Pausiert
                GetComponent<AudioSource>().Pause();
            }
            
        }
        
    }
    // Funktion zum anschalten 
    public void TurnOnCounter()
    {
        count--;
        if (count != neededActions)
        {
            // Alle Partikel in dem Array ewrden eingeschaltet
            foreach (var part in parts)
            {
                part.enableEmission = true;
                // Audio wird Angeschalten
                GetComponent<AudioSource>().Play();
            }
        }
        
    }

    //Funktion die partikel immer auf das gegenteil setzt
    //also wenn AN dann Aus und umgekehrt
    public void SwitchOnOff()
    {
        foreach (var part in parts)
        {
            part.enableEmission = !part.enableEmission;
        }
    }
}
