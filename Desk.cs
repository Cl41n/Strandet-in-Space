using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk : MonoBehaviour
{
    [SerializeField] private GameObject[] sliders;
    [SerializeField] GameObject display;


    public bool isWorking;
    
    // Start is called before the first frame update
    void Start()
    {
        // er nicht Funktionert wird das Material gewechselt
        if (!isWorking)
        {
            display.GetComponent<ChangeMaterial>().ToggleMaterial();
        }
    }

    

    public void StatusSlider()
    {
        // alle Slider in dem Array werden An oder Aus geschltet
        foreach (var slider in sliders)
        {
            slider.GetComponentInChildren<Slider>().Status();
            
        }
        
    }
}
