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
        // ausw�rfel der Geschindigkeit
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
            // wird es zerst�rt
            Destroy(gameObject);
        }

        // falls es mit Spieler Kollidiert 
        if (collision.gameObject.CompareTag("Player"))
        {
            // Wird dem Spieler ein Leben abgezogen
            hpManager.GetComponent<HpManager>().HpMinus();
            // und die Kugel zerst�rt
            Destroy(gameObject);
        }

        // falls er mit dem SChl�ger kollidiert
        if (collision.gameObject.CompareTag("bat"))
        {
            // wird das Tag der Kugel ge�ndert
            transform.gameObject.tag = "FriendlyBullet";
            // und seine Material ge�dert
            GetComponent<ChangeMaterial>().SetOtherMaterial();
           
        }
    }
}
