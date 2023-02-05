using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldHeight : MonoBehaviour
{
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        // Start position speichern
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Falls sich die position y von der Start Position y unterscheidet.
        if (transform.position.y != startPos.y)
        {
            // wird die position y wieder auf die startpostion y gesetzt
            transform.position = new Vector3(transform.position.x, startPos.y, transform.position.z);
        }
        
    }
}
