using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=UnityEngine.Random;

public class AmbienceSoundManager : MonoBehaviour
{
    //liste Sound Quellen
    [SerializeField] private GameObject[] soundSource;

    private bool playSound;
    

    void Start()
    {
        playSound = true;
        // Starten der Counrutine
        StartCoroutine(Sound());
    }
    
    
    IEnumerator Sound()
    {
        //Loop so lange playSound True ist
        while (playSound)
        {
            // Random Variabeln
            var source = Random.Range(0, soundSource.Length);
            var track = Random.Range(0, 7);
            // WarteZeit
            yield return new WaitForSeconds(2);
            // Ausführen der Funktion mit den Random Variablen
            soundSource[source].GetComponent<PlaySoundFromList>().PlaySpecificSound(track);
           
            
            
        }
    }
}
