using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnParticleCollisionCollisionDmgToPlayer : MonoBehaviour
{
    [SerializeField] private int waitTime;
    private GameObject hpManager;

    private bool hitted = false;
    

    private void Start()
    {
        // Hp Manager wird automatisch durch Tag gesucht und zugewiesen
        hpManager = GameObject.FindGameObjectWithTag("HpManager");
    }

    
    
    // Wenn Particle kolliedieren
    private void OnParticleCollision(GameObject other)
    {
        // und der getroffen das Tga Player trägt und hitten nicht wahr ist
        if (other.CompareTag("Player") && !hitted)
        {
            hitted = true;
            // wird dem SPieler ein Leben abgezogen 
            hpManager.GetComponent<HpManager>().HpMinus();
            // und eine Coroutine ausgelöst 
            StartCoroutine(Wait());

        }
    }

    IEnumerator Wait()
    {
        // Coroutine wartet eine bestimmte Zeit bis sie hitted wieder auf false setzt
        yield return new WaitForSeconds(waitTime);
        hitted = false;
    }
}
