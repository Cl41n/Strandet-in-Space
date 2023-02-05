using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneTrigger : MonoBehaviour
{
    [SerializeField] private GameObject dummy;
    [SerializeField] private GameObject clone;
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject button;

    // Wenn Jemand den Trigger Betritt
    private void OnTriggerEnter(Collider other)
    {
        // Abfrage ob er das Tag Player tr�gt
        if (other.gameObject.CompareTag("Player"))
        {
            //Dummy ausschalten.
            dummy.SetActive(false);
            // CLone Anschalten
            clone.SetActive(true);
            // T�re verschlie�en
            door.GetComponent<PlayAnim>().PlayAnimationNoMatterWhat();
            // Kn�pfe ausschalten 
            button.GetComponent<Button>().IsNotWorking();
            // Trigger zerst�ren
            Destroy(gameObject);
        }
    }
}
