using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=UnityEngine.Random;

public class LaserBullet : MonoBehaviour
{
    private GameObject hpManager;
    private int speed;
    // Bei erstellen des Game Objektes
    private void Awake()
    {
        // zuweisen des Hp Managers
        hpManager = GameObject.FindGameObjectWithTag("HpManager");
        // auswürfel der Geschindigkeit
        speed = Random.Range(600, 1000);
        // setzen der Geschindigkeit
        GetComponent<Rigidbody>().AddForce(new Vector3(0,55,speed));
    }

    //Wenn das Game Objekt kollidiert
    void OnCollisionEnter(Collision collision)
    {
        // falls es mit layer 6 kollidiert
        if (collision.gameObject.layer == 6)
        {
            // wird es zerstört
            Destroy(gameObject);
        }

        // falls es mit Spieler Kollidiert 
        if (collision.gameObject.CompareTag("Player"))
        {
            // Wird dem Spieler ein Leben abgezogen
            hpManager.GetComponent<HpManager>().HpMinus();
            // und die Kugel zerstört
            Destroy(gameObject);
        }

        // falls er mit dem SChläger kollidiert
        if (collision.gameObject.CompareTag("bat"))
        {
            // wird das Tag der Kugel geändert
            transform.gameObject.tag = "FriendlyBullet";
            // und seine Material geädert
            GetComponent<ChangeMaterial>().SetOtherMaterial();
           
        }
    }
}
