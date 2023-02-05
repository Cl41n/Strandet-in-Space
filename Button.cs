using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Button : MonoBehaviour
{
    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadZone = 0.025f;
    [SerializeField] private bool isWorking;
    
    
    private bool isPressed;
    private Vector3 startPos;
    private ConfigurableJoint joint;

    public GameObject clicker;
    public UnityEvent onPressed, onReleased;
    public Transform startRotation;

    // Start is called before the first frame update
    void Start()
    {
        
        // Start Oistion speichern
        startPos = transform.localPosition;
        // Component aus dem GameObjekt zuweisen
        joint = GetComponent<ConfigurableJoint>();
        // Rontation auf den Joint übertragen
        joint.SetTargetRotationLocal(Quaternion.Euler(0, 90, 0), startRotation.localRotation);
        
        // Falls der Knopf funktioniert wird das Material geändert
        if (isWorking)
        {
            clicker.GetComponent<ChangeMaterial>().ToggleMaterial();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Ausführen der Events falls der Knopf tief genug gedrpückt ist und funktioniert
        if(isWorking){
            
            if (!isPressed && GetValue() + threshold >= 1)
            {
                Pressed();
            }
            if (isPressed && GetValue() - threshold <= 0)
            {
                Released();
            }
        }

        //Falls er nicht funktioniert Error sound spielen
        if (!isWorking)
        {
            if (!isPressed && GetValue() + threshold >= 1)
            {
                GetComponent<PlaySoundFromList>().PlaySoundInOrder();
            }
        }

        //Begrenzung der maximal Eindrücktiefe 
        if (transform.localPosition.y > startPos.y)
        {

            transform.localPosition = new Vector3(startPos.x, startPos.y , startPos.z);
        }
        if (transform.localPosition.y < startPos.y - 0.04f)
        {

            transform.localPosition = new Vector3(startPos.x, startPos.y - 0.04f, startPos.z);
        }
    }

    // Berechnung aab welcher Eindrücktiefe der Button auslöst
    private float GetValue()
    {
        var value = Vector3.Distance(startPos, transform.localPosition) /joint.linearLimit.limit;
        if (Math.Abs(value) < deadZone)
        {
            value = 0;
        }

        return Mathf.Clamp(value, -1f, 1f);
    }

    // Ausführen des Gedrückt Events
    private void Pressed()
    {
        isPressed = true;
        onPressed.Invoke();
        
    }

    // Ausführen des Losgelasssen Events
    private void Released()
    {
        isPressed = false;
        onReleased.Invoke();
      

    }

    // Status des Knopf auf sein Gegeteil stellen 
    // also wenn er an ist geth er aus und umgekehrt
    public void Status()
    {
        isWorking = !isWorking;
        //mateiral wechseln
        clicker.GetComponent<ChangeMaterial>().ToggleMaterial();
        
    }

    // Knopf anschalten
    public void IsWorking()
    {
        isWorking = true;
        //mateiral wechseln
        clicker.GetComponent<ChangeMaterial>().SetOtherMaterial();
    }
    // Knopf ausschalten
    public void IsNotWorking()
    {
        isWorking = false;
        //mateiral wechseln
        clicker.GetComponent<ChangeMaterial>().SetOriginalMaterial();
    }
}
