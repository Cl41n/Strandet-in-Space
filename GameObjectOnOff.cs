using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectOnOff : MonoBehaviour
{
   [SerializeField] private GameObject gameObject;
   [SerializeField] private bool isActive;

   private void Start()
   {
      // falls das Gameobjekt aktive sein soll
      if (isActive)
      {
         //wird es hier aktiviert
         gameObject.SetActive((true));
      }

      // falls das Gameobjekt deaktiviert sein soll
      if (!isActive)
      {
         // wird es hier deaktiviert 
         gameObject.SetActive((false));
      }
   }

    //Funktion zum Aktivieren des GameObjekts
   public void SetActive()
   {
      isActive = true;
      gameObject.SetActive((true));
   }

    //Funktion zum Deaktivieren des GameObjekts
   public void SetInactive()
   {
      
      isActive = false;
      gameObject.SetActive((false));
   }

    // Funktion zum setzten des Status auf das Gegenteil
   public void SwitchStatus()
   {
      isActive = !isActive;
      if (isActive)
      {
         gameObject.SetActive((true));
      }

      if (!isActive)
      {
         gameObject.SetActive((false));
      }
   }

}
