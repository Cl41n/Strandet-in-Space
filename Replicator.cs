using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replicator : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject buttonL;
    [SerializeField] private GameObject buttonR;
    [SerializeField] private GameObject spawnPoint;

    // Funktion zum herstellen des Objektes
    public void Craft()
    {
       //Spawnen des Prefabs
        Instantiate(prefab, spawnPoint.transform.position , spawnPoint.transform.rotation);
        //Kn�pfe ausschalten 
        TurnButtonsOff();
    }

    // Funktion zum ausschalten der Kn�pfe
    private void TurnButtonsOff()
    {
        // kn�pfe aussschalten
        buttonL.GetComponent<Button>().IsNotWorking();
        buttonR.GetComponent<Button>().IsNotWorking();
    }
    
    // Funktion zum Anschalten der Kn�pfe
    private void TurnButtonsOn()
    {
        // Kn�pfe werden angeschaltet
        buttonL.GetComponent<Button>().IsWorking();
        buttonR.GetComponent<Button>().IsWorking();
    }

    // Wenn das Objekt den Trigger verl�sst
    void OnTriggerExit(Collider other)
    {
        //falls der Tag des Objektes bat ist
        if (other.gameObject.CompareTag("bat"))
        {
            // werden die Kn�pfe wieder angeschaltet
            TurnButtonsOn();
        }
    }
}
