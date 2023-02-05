using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Slider : MonoBehaviour
{
    [SerializeField] private bool startBot;
    [SerializeField] private bool isWorking;
    public Transform startRotation;
    private ConfigurableJoint joint;
    private Vector3 startPos;
    private bool activate;
    public UnityEvent activated, deactivated;
    
    // Start is called before the first frame update
    void Start()
    {
        activate = false;
        //Speichern der Start pos
        startPos = transform.localPosition; 
        // zuweisen des Joints
        joint = GetComponent<ConfigurableJoint>();
        // rotaion auf den Joint übertragen
        joint.SetTargetRotationLocal(Quaternion.Euler(0, 90, 0), startRotation.localRotation);
        if (startBot)
        {
            //falls startBot True is wird die position des Schiebers nach unten verschoben
            transform.localPosition = new Vector3(startPos.x, startPos.y + -0.05f, startPos.z);
        }
        if (isWorking)
        {
            // falls der Schieber funktioniert wird das material geändert
            GetComponent<ChangeMaterial>().ToggleMaterial();
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        //Abfragen um zu überprüfen ob der Schieber seine maximale position überschritten hat
        //Schieber wird dann gegebenfalss zurück gesetzt
        if(transform.localPosition.y > startPos.y + 0.05f)
        {
            
            transform.localPosition = new Vector3(startPos.x, startPos.y + 0.05f, startPos.z);
        }
        if (transform.localPosition.y < startPos.y - 0.05f)
        {

            transform.localPosition = new Vector3(startPos.x, startPos.y - 0.05f, startPos.z);
        }

        //falls er die höchste position erreicht hat wird Top ausgeführt
        if (isWorking&&!activate && transform.localPosition.y > startPos.y + 0.049f)
        {
            
            Top();
        }
        //falls er die niedrigste position erreicht hat wird Bot ausgeführt
        if (isWorking&&activate && transform.localPosition.y < startPos.y - 0.049f)
        {
            
            Bot();
        }
        
        
    }
    
    //Funktion zum auslösen des Events
    private void Top ()
    {
        activate = true;
        activated.Invoke();
        
    }

    //Funktion zum auslösen des Events
    private void Bot()
    {
        activate = false;
        deactivated.Invoke();
    }
    //Funktion zum An und Ausschalten
    public void Status()
    {
        isWorking = !isWorking;
        GetComponent<ChangeMaterial>().ToggleMaterial();
        
    }
}
