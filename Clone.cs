using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=UnityEngine.Random;

public class Clone : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject glowingPart;
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private int hP;
    private Vector3 playerStartPos;
    private bool alive;
    private int waitTime;
    private bool sound;
   
    // Gespiegelte Position berechnen
    private float Movement (float lastPos, float currentPos)
    {
        return lastPos - currentPos;
    }
    private void Start()
    {
        sound = true;
        alive = true;
        playerStartPos = player.transform.position;
        //Coroutine Fire wird gestartet
        StartCoroutine(Fire());
    }

    private void FixedUpdate()
    {
        // Wenn der Roboter am Leben ist wird er Bewegt
        if(alive)
        {
            transform.position = new Vector3(player.transform.position.x,0.5f, Movement( playerStartPos.z, player.transform.position.z) - 10);
            
        }
        // Wenn er nicht am Leben ist und Sound an ist wird der Sound abgeschaltet
        if (!alive && sound)
        {
            sound = false;
            GetComponent<AudioSource>().Pause();
        }
        
       
    }

    // Fuktion zum Spawnen der Kugeln
    private void Shoot()
    {
        // Prefab der Kugel wird gespawnt
        Instantiate(ballPrefab, new Vector3(transform.position.x,transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
    }

    // Collisionsabfrage ob der Roboter vom SPieler getroffen wurde
    private void OnCollisionEnter(Collision collision)
    {
        // falls ja verleirt er ein Leben
        if (collision.gameObject.CompareTag("FriendlyBullet"))
        {
            hP--;
            // falls sein leben auf 0 oder darunter fällt wird Materials gewechselt
            if (hP <= 0)
            {
                alive = false;
                glowingPart.GetComponent<ChangeMaterial>().SetOtherMaterial();
                // und alle Knöpfe in dem Array angeschaltet
                foreach (var button in buttons)
                {
                    button.GetComponent<Button>().Status();
                }
            }
        }

    }

    //Coroutine
    IEnumerator Fire()
    {
        // Schießt so lange der Roboter am leben ist
        while (alive)
        {
            // zufällige Wartezeit wird gewürfelt
            waitTime = Random.Range(1, 4);
            // Zeit wird abgewartet
            yield return new WaitForSeconds(waitTime);
            // Schießenfukzion ausgefährt
            Shoot(); 
        }
    }

        

    
    

    
}
