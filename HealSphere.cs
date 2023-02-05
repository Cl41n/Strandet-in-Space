using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealSphere : MonoBehaviour
{
    private GameObject hpManager;
    private bool used = false;

    // Sobald das Game Objekt erstellt wird 
    private void Awake()
    {
        //sucht es sich selber den HP Manager über seinen Tag
        hpManager = GameObject.FindGameObjectWithTag("HpManager");
    }

    // Funktion zum benutzen der Heil Kugel
    public void Use()
    {
        // erhallen der Hp werte vom HP Manager
        var hp = hpManager.GetComponent<HpManager>().CurrentHp();
        // Falls das Leben kleiner als 3 ist und der Ball noch nicht benutzt wurde
        if (hp < 3 && !used)
        {
            used = true;
            // funktion zum HP erhöhen
            hpManager.GetComponent<HpManager>().HpPlus();
            // Material wechsel
            GetComponent<ChangeMaterial>().SetOtherMaterial();
            // Sound abspielen
            GetComponent<PlaySoundFromList>().PlaySpecificSound(0);
        }
        else
        {
            // Sound abspeiel wenn der ball nicht funktioniert
            GetComponent<PlaySoundFromList>().PlaySpecificSound(1);
        }
    }
}
