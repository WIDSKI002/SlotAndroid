using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
//using static money_score;
public class mnoznik : MonoBehaviour
{

    [SerializeField] private Button clickButton;
    [SerializeField] private int dzialanie = 1;
    [SerializeField] private Text timeText;
    [SerializeField] private Text staticText;
    [SerializeField] private money_score gameManager;
    [SerializeField] private spin spin;
    [SerializeField] private money_score money_score;
    void Awake()
    {
        clickButton.onClick.AddListener(OnClick);
        staticText.text = "Mno¿nik(" +   zmienna.mnoznik + ")";
       
    }
    void FixedUpdate()
    {
        buttonmnoznik();
     



    }
     void buttonmnoznik() {

        if (spin.freespin > 0)
        {
            clickButton.interactable = false;
        }
        else
        {

            if (spin.spinning)
            {
                clickButton.interactable = false;
            }
            else
            {
                if (dzialanie == 1)
                {
                    if (zmienna.wartosc == 8)
                    {
                        clickButton.interactable = false;
                    }
                    else
                    {
                        clickButton.interactable = true;
                    }
                }
                else
                {
                    if (zmienna.wartosc == 1)
                    {
                        clickButton.interactable = false;
                    }
                    else
                    {
                        clickButton.interactable = true;
                    }
                }
            }
        }

    }
    
    void OnClick()
    {
     
        if (dzialanie == 1)
        {
            ++(zmienna.wartosc);
          
            switch (zmienna.wartosc)
            {
                case 1:
                    zmienna.mnoznik = 1;
                    break;
                case 2:
                    zmienna.mnoznik = 2;
                    break;
                case 3:
                    zmienna.mnoznik = 4;
                    break;
                case 4:
                    zmienna.mnoznik = 5;
                    break;
                case 5:
                    zmienna.mnoznik = 10;
                    break;
                case 6:
                    zmienna.mnoznik = 20;
                    break;
                case 7:
                    zmienna.mnoznik = 50;
                    break;
                case 8:
                    zmienna.mnoznik = 100;
                    break;
                default:
                    zmienna.mnoznik = 1;
                    break;
            }
           
              
        }
        else
        {
           
            --(zmienna.wartosc);

            switch (zmienna.wartosc)
            {
                case 1:
                    zmienna.mnoznik = 1;
                    break;
                case 2:
                    zmienna.mnoznik = 2;
                    break;
                case 3:
                    zmienna.mnoznik = 4;
                    break;
                case 4:
                    zmienna.mnoznik = 5;
                    break;
                case 5:
                    zmienna.mnoznik = 10;
                    break;
                case 6:
                    zmienna.mnoznik = 20;
                    break;
                case 7:
                    zmienna.mnoznik = 50;
                    break;
                case 8:
                    zmienna.mnoznik = 100;
                    break;
                default:
                    zmienna.mnoznik = 1;
                    break;
            }
        
      

        }
        staticText.text = "Mno¿nik(" + zmienna.mnoznik + ")";
        timeText.text = "SPIN(" + (spin.startcost * zmienna.mnoznik) + ")";

        money_score.tabelawartosci();
    }
   
}
