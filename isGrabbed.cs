using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isGrabbed : MonoBehaviour
{
    // Funktions wenn der Gegenstand ausgehoben wird
    public void grabbed()
    {
        // das Game Objekt und all seine Kinder werden auf layer 12 gesetzt.
        // Layer 12 kann nicht mit dem Spieler Kollidieren
        gameObject.layer = 12;
        foreach (Transform child in transform)
        {
            child.gameObject.layer = 12;
        }
    }

    //Funktion wenn das Game Objekt fallen gelassen wird
    public void released()
    {
        // Das Game objekt und all seine Kinder werden auf layer 0 gesetzt
        gameObject.layer = 0;
        foreach (Transform child in transform)
        {
            child.gameObject.layer = 0;
        }
    }



 }