using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        // Startposition gespecihert
        startPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        // Wenn die position y der Start position y ungelich sind
        if(transform.localPosition.y != startPos.y)
        {
            // wird die position y wieder auf die start position gestzt
            transform.localPosition =  new Vector3(transform.localPosition.x, startPos.y, transform.localPosition.y); 
        }

        
    }
}
