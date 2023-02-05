using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnim : MonoBehaviour
{
    [SerializeField] private Animator anim;

    [SerializeField] private string[] clips; 
    private float waitTime;
    private bool isPlaying;
    private int currentClip;

    private void Start()
    {
        // Momentaner Clip auf 0 setzten.
        currentClip = 0;
    }

    private void FixedUpdate()
    {
        // Wenn is playing wahr ist 
        if (isPlaying)
        {
            // wird die Zeit abgezogen 
            waitTime -= Time.deltaTime;
            // sobald sie auf 0 fällt ist der Clip zuende und is Playing wird wieder auf false gesetzt
            if (waitTime <= 0)
            {
                isPlaying = false;
            }
        }
    }

    // Fuktipn zum Spielen einer Animation
    public void PlayAnimation()
    {
        // falls gerade keine ANimation läuft
        if(!isPlaying){
            // falls currentclip größer als Clips Array länge ist
            if (currentClip > clips.Length - 1)
            {
                // wird current clip wieder auf 0 gestzt
                currentClip = 0;
            }

            isPlaying = true;
            //animation wird abgespielt
            anim.Play(clips[currentClip],0,0.0f);
            RuntimeAnimatorController ac = anim.runtimeAnimatorController;
            //waittime gespeichert
            waitTime = ac.animationClips.Length;
            // current clip hochgezählt
            currentClip += 1;
        }
    }

    // Funktion zum abspielen einer animatiopn ohne auf isPlaying zu achten
    public void PlayAnimationNoMatterWhat()
    {
        // falls currentclip größer als Clips Array länge ist
        if (currentClip > clips.Length - 1)
        {
            // wird current clip wieder auf 0 gestzt
            currentClip = 0;
        }
        // Animation wird abgespielt
        anim.Play(clips[currentClip], 0, 0.0f);
        currentClip += 1;
    }
}
