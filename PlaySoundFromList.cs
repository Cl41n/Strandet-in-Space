using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundFromList : MonoBehaviour
{

    
    [SerializeField] AudioClip[] clips;

    private AudioSource source;
    private float waitTime;
    private bool isPlaying;
    private int currentClip;

    
    void Start()
    {
        // AudioSource wird zugewieﬂen
        source = GetComponent<AudioSource>();
        isPlaying = false;
        currentClip = 0;
    }

    private void FixedUpdate()
    {
        // wenn isPlaying zutrifft
        if(isPlaying)
        {
            //wird Zeit von der waitTime angezogen
            waitTime -= Time.deltaTime;
            // wenn waitTime kleiner gleich 0 ist
            if(waitTime <= 0)
            {
                // wird isPlaying auf false gesetzt
                isPlaying = false;
            }
        }
    }

    // Funktion zum Spielen eines Sounds aus dem Array
    public void PlaySpecificSound(int clip)
    {
        // wenn is Playing nicht wahr ist
        if (!isPlaying)
        {
            // Wird der gew¸nschte Clip abgespielt
            isPlaying = true;
            waitTime = clips[clip].length;
            source.PlayOneShot(clips[clip]);

       
        }
    }
    
    // Funktion um Sounds der Reihe nach abspielen
    public void PlaySoundInOrder()
    {
        // wenn is Playing nicht wahr ist
        if (!isPlaying)
        {
            //fallse currentClip grˆﬂer ist als die Array l‰nge
            if (currentClip > clips.Length - 1)
            {
                // wird current clip auf 0 gesetzt
                currentClip = 0;
            }
            //current clip wird abgespielt
            isPlaying = true;
            waitTime = clips[currentClip].length;
            source.PlayOneShot(clips[currentClip]);
            currentClip += 1;
        }
    }
}