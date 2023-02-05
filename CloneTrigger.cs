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
        // Abfrage ob er das Tag Player trägt
        if (other.gameObject.CompareTag("Player"))
        {
            //Dummy ausschalten.
            dummy.SetActive(false);
            // CLone Anschalten
            clone.SetActive(true);
            // Türe verschließen
            door.GetComponent<PlayAnim>().PlayAnimationNoMatterWhat();
            // Knöpfe ausschalten 
            button.GetComponent<Button>().IsNotWorking();
            // Trigger zerstören
            Destroy(gameObject);
        }
    }
}
