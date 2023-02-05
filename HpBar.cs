using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    
    
    [SerializeField] private Image[] imgs;
    [SerializeField] Gradient colors;
    [SerializeField] float maxValue;
    [SerializeField] float minValue;
    [SerializeField] private Color basicColor;
    private int hP;
    // Start is called before the first frame update
    void Start()
    {
        // HP bar Auf Maximale Leben einstellen
        UpdateHpBar(maxValue);
    }

    // Funktion zum Aktualisieren der Hp Leiste
    public void UpdateHpBar(float value)
    {
        // Falls der Leben 3 ist
        if (value == 3)
        {
            // werden die Bilder im Array imgs an die Neue Farbe angepasst
            foreach (var img in imgs)
            {
                // berechnung des gefüllten bereichs
                float fillAmount = Mathf.InverseLerp(minValue, maxValue, value);
                // Color bestimmen mit dem fillAmount
                Color color = colors.Evaluate(fillAmount);
                // Farbe setzten
                img.color = color;
            }
        }

        if (value == 2)
        {
            // berechnung des gefüllten bereichs
            float fillAmount = Mathf.InverseLerp(minValue, maxValue, value);
            // Color bestimmen mit dem fillAmount
            Color color = colors.Evaluate(fillAmount);
            // Färben der bestimmen Bilder
            imgs[0].color = color;
            imgs[1].color = color;
            imgs[2].color = basicColor;
        }
        
        if (value == 1)
        {
            // berechnung des gefüllten bereichs
            float fillAmount = Mathf.InverseLerp(minValue, maxValue, value);
            // Color bestimmen mit dem fillAmount
            Color color = colors.Evaluate(fillAmount);
            // Färben der bestimmen Bilder
            imgs[0].color = color;
            imgs[1].color = basicColor;
            imgs[2].color = basicColor;
        }
        
        if (value == 0)
        {
            // Färben der bestimmen Bilder
            imgs[0].color = basicColor;
            imgs[1].color = basicColor;
            imgs[2].color = basicColor;
        }
        
        
        
    }
   
}
