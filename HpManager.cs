using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HpManager : MonoBehaviour
{
    private int hP;

    [SerializeField] GameObject hpBar;

    // Bei spielstart die Hp auf 3 setzen
    private void Start()
    {
        hP = 3;
    }

    // Funktions zum hinzufügen von einem Leben
    public void HpPlus()
    {
        Debug.Log(hP);
        if(hP < 3) 
        { 
            hP++;
            hpBar.GetComponent<HpBar>().UpdateHpBar(hP);
        }
    }
    // Funktions zum abziehen von einem Leben
    public void HpMinus()
    {
        Debug.Log(hP);
        hP--;
        if(hP == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
           hpBar.GetComponent<HpBar>().UpdateHpBar(hP);
        }
       
    }
    // FUnktion die die Currrent HP zurück gibt
    public int CurrentHp()
    {
        return hP;
    }


}
