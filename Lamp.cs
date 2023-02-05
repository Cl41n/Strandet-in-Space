using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    private Light _light;
    public GameObject slider;
    // Start is called before the first frame update
    void Start()
    {
        //Zuweisen des Kompoments Light
        _light = GetComponent<Light>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //Light intesity wird verändert je nach Slider Position Heller oder Dunkler
        _light.intensity = (slider.transform.localPosition.y + 0.05f) * 100;
    }
}
