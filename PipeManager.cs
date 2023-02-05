using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeManager : MonoBehaviour
{
   [Header("---Outlet---")] 
   private bool OutletTwoWorking;

   [Header("---FinalButton---")] 
   [SerializeField] private GameObject finalButton;
   private bool finalButtonPartOneActive;
   private bool finalButtonPartTwoActive;
   
   
   [Header("---LineOne---")]
   [SerializeField] private GameObject[] pipeLineOne;
   [SerializeField] private GameObject buttonLineOne;
   private bool pipeLineOnePower;
   private bool pipeLineOneSlotOne;
   private bool pipeLineOneSlotTwo;
   
   
   
   [Header("---LineTwo---")]
   [SerializeField] private GameObject[] pipeLineTwo;
   private bool pipeLineTwoPower;
   private bool pipeLineTwoSlotOne;
   private bool pipeLineTwoSlotTwo;
   private bool pipeLineTwoSlotTrhee;
   
   
   [Header("---LineThree---")]
   [SerializeField] private GameObject[] pipeLineThree;
   private bool pipeLineThreePower;
   private bool pipeLineThreeSlotOne;
   private bool pipeLineThreeSlotTwo;
   
   
   
   [Header("---LineFour---")]
   [SerializeField] private GameObject[] pipeLineFour;
   [SerializeField] private GameObject buttonLineFour;
   private bool pipeLineFourPower;
   private bool pipeLineFourSlotOne;
 
   [Header("---LineFive---")]
   [SerializeField] private GameObject[] pipeLineFive;
   private bool pipeLineFivePower;
   private bool pipeLineFiveSlotOne;
   
   
   


   private void Awake()
   {
      OutletTwoWorking = false;
      
      pipeLineOneSlotOne = false;
      pipeLineOneSlotTwo = false;
      
      
      pipeLineTwoSlotOne = false;
      pipeLineTwoSlotTwo = false;
      pipeLineTwoSlotTrhee = false;

      pipeLineThreePower = false;
      pipeLineThreeSlotOne = false;
      pipeLineThreeSlotTwo = false;
      
      pipeLineFourPower = false;
      pipeLineFourSlotOne = false;
      
      pipeLineFivePower = false;
      pipeLineFiveSlotOne = false;
      
      finalButtonPartOneActive = false;
      finalButtonPartTwoActive = false;

   }

   //PipeLineOne
   public void PipeLineOnePowerOn()
   {
      
      pipeLineOnePower = true;
      PipeLineOne();

   }
   
   public void PipeLineOnePowerOff()
   {
      pipeLineOnePower = false;
      PipeLineOne();
   }
   
   public void PipelineOneSlotOne()
   {
      pipeLineOneSlotOne = !pipeLineOneSlotOne;
      PipeLineOne();
      
   }
   
   public void PipelineOneSlotTwo()
   {
      pipeLineOneSlotTwo = !pipeLineOneSlotTwo;
      PipeLineOne();
   }

   private void PipeLineOne()
   {
      
      if (pipeLineOnePower)
      {
         pipeLineOne[0].GetComponent<ChangeMaterial>().SetOtherMaterial();
         
         if (pipeLineOneSlotOne)
         {
            pipeLineOne[1].GetComponent<ChangeMaterial>().SetOtherMaterial();
         }
         
         if (pipeLineOneSlotTwo)
         {
            for (int i = 2; i < pipeLineOne.Length; i++)
            {
               pipeLineOne[i].GetComponent<ChangeMaterial>().SetOtherMaterial();
            }
            buttonLineOne.GetComponent<Button>().IsWorking();
         }
         
         if (!pipeLineOneSlotOne)
         {
            pipeLineOne[1].GetComponent<ChangeMaterial>().SetOriginalMaterial();
            for (int i = 2; i < pipeLineOne.Length; i++)
            {
               pipeLineOne[i].GetComponent<ChangeMaterial>().SetOriginalMaterial();
            }
            buttonLineOne.GetComponent<Button>().IsNotWorking();
         }
         
         if (!pipeLineOneSlotTwo)
         {
            for (int i = 2; i < pipeLineOne.Length; i++)
            {
               pipeLineOne[i].GetComponent<ChangeMaterial>().SetOriginalMaterial();
            }
            buttonLineOne.GetComponent<Button>().IsNotWorking();
         }
      }

      if (!pipeLineOnePower)
      {
         foreach (var pipe in pipeLineOne)
         {
            pipe.GetComponent<ChangeMaterial>().SetOriginalMaterial();
         }
         buttonLineOne.GetComponent<Button>().IsNotWorking();
      }
   }
   
   //PipeLineTwo
   public void PipeLineTwoPowerOn()
   {
      
      pipeLineTwoPower = true;
      PipeLineTwo();

   }
   
   public void PipeLineTwoPowerOff()
   {
      pipeLineTwoPower = false;
      PipeLineTwo();
   }
   
   public void PipelineTwoSlotOne()
   {
      pipeLineTwoSlotOne = !pipeLineTwoSlotOne;
      PipeLineTwo();
      
   }
   
   public void PipelineTwoSlotTwo()
   {
      pipeLineTwoSlotTwo = !pipeLineTwoSlotTwo;
      PipeLineTwo();
   }
   
   public void PipelineTwoSlotThree()
   {
      pipeLineTwoSlotTrhee = !pipeLineTwoSlotTrhee;
      PipeLineTwo();
   }

   private void  PipeLineTwo()
   {
      if (pipeLineTwoPower)
      {
         pipeLineTwo[0].GetComponent<ChangeMaterial>().SetOtherMaterial();
         pipeLineTwo[1].GetComponent<ChangeMaterial>().SetOtherMaterial();

         if (pipeLineTwoSlotOne)
         {
            pipeLineTwo[2].GetComponent<ChangeMaterial>().SetOtherMaterial();
         }
         
         if (pipeLineTwoSlotTwo)
         {
            pipeLineTwo[3].GetComponent<ChangeMaterial>().SetOtherMaterial();
            pipeLineTwo[4].GetComponent<ChangeMaterial>().SetOtherMaterial();
            pipeLineTwo[5].GetComponent<ChangeMaterial>().SetOtherMaterial();
            
         }

         

         if (!pipeLineTwoSlotOne)
         {
            for (int i = 2; i < pipeLineTwo.Length; i++)
            {
               pipeLineTwo[i].GetComponent<ChangeMaterial>().SetOriginalMaterial();
            }
            OutletTwoWorking = false;
         }
         
         if (!pipeLineTwoSlotTwo)
         {
            for (int i = 3; i < pipeLineTwo.Length; i++)
            {
               pipeLineTwo[i].GetComponent<ChangeMaterial>().SetOriginalMaterial();
            }
            OutletTwoWorking = false;
         }
         if (!pipeLineTwoSlotTrhee)
         {
            OutletTwoWorking = false;
            
         }

         if (pipeLineTwoSlotOne && pipeLineTwoSlotTwo && pipeLineTwoSlotTrhee)
         {
            OutletTwoWorking = true;
         }
      }
      
      if (!pipeLineTwoPower)
      {
         foreach (var pipe in pipeLineTwo)
         {
            pipe.GetComponent<ChangeMaterial>().SetOriginalMaterial();
         }
         OutletTwoWorking = false;
         
      }
      
      PipeLineFour();
      PipeLineFive();
   }
   
   //PipeLineThree
   public void PipeLineThreePowerOn()
   {
      
      pipeLineThreePower = true;
      PipeLineThree();

   }
   
   public void PipeLineThreePowerOff()
   {
      pipeLineThreePower = false;
      PipeLineThree();
   }
   
   public void PipelineThreeSlotOne()
   {
      pipeLineThreeSlotOne = !pipeLineThreeSlotOne;
      PipeLineThree();
      
   }
   
   public void PipelineThreeSlotTwo()
   {
      pipeLineThreeSlotTwo = !pipeLineThreeSlotTwo;
      PipeLineThree();
   }

   private void PipeLineThree()
   {
      
      if (pipeLineThreePower)
      {
        
         
         if (pipeLineThreeSlotOne)
         {
            pipeLineThree[0].GetComponent<ChangeMaterial>().SetOtherMaterial();
            pipeLineThree[1].GetComponent<ChangeMaterial>().SetOtherMaterial();
         }
         
         if (pipeLineThreeSlotTwo)
         {
            for (int i = 2; i < pipeLineThree.Length; i++)
            {
               pipeLineThree[i].GetComponent<ChangeMaterial>().SetOtherMaterial();
            }
            finalButtonPartOneActive = true;
            FinalButton();
         }
         
         if (!pipeLineThreeSlotOne)
         {
            pipeLineThree[0].GetComponent<ChangeMaterial>().SetOriginalMaterial();
            pipeLineThree[1].GetComponent<ChangeMaterial>().SetOriginalMaterial();
            for (int i = 2; i < pipeLineThree.Length; i++)
            {
               pipeLineThree[i].GetComponent<ChangeMaterial>().SetOriginalMaterial();
            }
            finalButtonPartOneActive = false;
            FinalButton();
         }
         
         if (!pipeLineThreeSlotTwo)
         {
            for (int i = 2; i < pipeLineThree.Length; i++)
            {
               pipeLineThree[i].GetComponent<ChangeMaterial>().SetOriginalMaterial();
            }
            
            finalButtonPartOneActive = false;
            FinalButton();
         }
      }

      if (!pipeLineThreePower)
      {
         foreach (var pipe in pipeLineThree)
         {
            pipe.GetComponent<ChangeMaterial>().SetOriginalMaterial();
         }
         
         finalButtonPartOneActive = false;
         FinalButton();
      }
   }
   
   //PipeLineFour
   
   public void PipeLineFourPowerOn()
   {
      pipeLineFourPower = true;
      PipeLineFour();
   }
   
   public void PipeLineFourPowerOff()
   {
      pipeLineFourPower = false;
      PipeLineFour();
   }
   
   public void PipelineFourSlotOne()
   {
      pipeLineFourSlotOne = !pipeLineFourSlotOne;
      PipeLineFour();
     
      
   }
   
   private void PipeLineFour()
   {
      if (OutletTwoWorking)
      {
         if (pipeLineFourPower)
         {
            for (int i = 0; i < 5; i++)
            {
               pipeLineFour[i].GetComponent<ChangeMaterial>().SetOtherMaterial();
            }
         

            if (pipeLineFourSlotOne)
            {
               pipeLineFour[5].GetComponent<ChangeMaterial>().SetOtherMaterial();
               buttonLineFour.GetComponent<Button>().IsWorking();
            }
            
            if (!pipeLineFourSlotOne)
            {
               pipeLineFour[5].GetComponent<ChangeMaterial>().SetOriginalMaterial();
               buttonLineFour.GetComponent<Button>().IsNotWorking();
            }
         }
         if (!pipeLineFourPower)
         {
            foreach (var pipe in pipeLineFour)
            {
               pipe.GetComponent<ChangeMaterial>().SetOriginalMaterial();
            }
            buttonLineFour.GetComponent<Button>().IsNotWorking();
         }
      }
      if (!OutletTwoWorking)
      {
         foreach (var pipe in pipeLineFour)
         {
            pipe.GetComponent<ChangeMaterial>().SetOriginalMaterial();
         }
         buttonLineFour.GetComponent<Button>().IsNotWorking();
      }
   }
   
   
   //PipeLineFive
   public void PipeLineFivePowerOn()
   {
      pipeLineFivePower = true;
      PipeLineFive();
   }
   
   public void PipeLineFivePowerOff()
   {
      pipeLineFivePower = false;
      PipeLineFive();
   }
   
   public void PipelineFiveSlotOne()
   {
      pipeLineFiveSlotOne = !pipeLineFiveSlotOne;
      PipeLineFive();
     
      
   }
   private void PipeLineFive()
   {
      if (OutletTwoWorking)
      {
         if (pipeLineFivePower)
         {
            for (int i = 0; i < 4; i++)
            {
               pipeLineFive[i].GetComponent<ChangeMaterial>().SetOtherMaterial();
            }
         

            if (pipeLineFiveSlotOne)
            {
               foreach (var pipe in pipeLineFive)
               {
                  pipe.GetComponent<ChangeMaterial>().SetOtherMaterial();
               }

               finalButtonPartTwoActive = true;
               FinalButton();
            }

            if (!pipeLineFiveSlotOne)
            {
               for (int i = 4; i < pipeLineFive.Length-1; i++)
               {
                  pipeLineFive[i].GetComponent<ChangeMaterial>().SetOriginalMaterial();
               }
               finalButtonPartTwoActive = false;
               FinalButton();
            }

            
         }
         if (!pipeLineFivePower)
         {
            foreach (var pipe in pipeLineFive)
            {
               pipe.GetComponent<ChangeMaterial>().SetOriginalMaterial();
            }

            finalButtonPartTwoActive = false;
            FinalButton();
         }
      }
      if (!OutletTwoWorking)
      {
         foreach (var pipe in pipeLineFive)
         {
            pipe.GetComponent<ChangeMaterial>().SetOriginalMaterial();
         }

         finalButtonPartTwoActive = false;
         FinalButton();
      }

   }

   private void FinalButton()
   {
      if (finalButtonPartOneActive && finalButtonPartTwoActive)
      {
         finalButton.GetComponent<Button>().IsWorking();
      }
      else
      {
         finalButton.GetComponent<Button>().IsNotWorking();
      }
   }
}

