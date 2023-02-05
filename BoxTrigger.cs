using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTrigger : MonoBehaviour
{

    [SerializeField] GameObject[] buttons;
    [SerializeField] private int neededBoxes;
    [SerializeField] private GameObject[] gates;
    private int counter;

    //Abfrage auf Collsion
    private void OnTriggerEnter(Collider other)
    {
        // Abfragen nach Tag des Collendieren Objekts
        if (other.gameObject.CompareTag("Box"))
        {
            counter++;
            BoxCounter();
        }
    }

    //Abfrage nach verlassendem Objekt
    private void OnTriggerExit(Collider other)
    {
        // Abfragen nach Tag des Collendieren Objekts
        if (other.gameObject.CompareTag("Box"))
        {
            counter--;
            
        }
    }

    // Funktions zum Zählen der Kisten
    private void BoxCounter()
    {
        // Abfrage ob die gewünschte Menge erreicht ist
        if (counter == neededBoxes)
        {
            // Apsielen der Animation und des Sounds der Tore in dem Array gates
            foreach (var gate in gates)
            {
                gate.GetComponent<PlayAnim>().PlayAnimation();
                gate.GetComponent<PlaySoundFromList>().PlaySoundInOrder();
            }

            // An schalten aller Knöpfe in dem Array buttons
            foreach (var button in buttons)
            {
                button.GetComponent<Button>().Status();
            }
            
        }
    }
    
}
