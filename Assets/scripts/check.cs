using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class check : MonoBehaviour
{
    [SerializeField] public int cena = 20000;
    [SerializeField] private bool kupione1 = false;
    [SerializeField] private bool kupione2 = false;
    [SerializeField] private bool kupione3 = false;
    [SerializeField] private bool kupione4 = false;
    [SerializeField] private bool kupione5 = false;
    [SerializeField] public static int j;

    [SerializeField] private scena_asy scenaAsy; // Dodaj to pole
    [SerializeField] private GameObject GameObject;
    [SerializeField] private GameObject Game;
    [SerializeField] private GameObject kup;
    [SerializeField] private Button tak;
    [SerializeField] private GameObject[] blokada;
    [SerializeField] private text text;
    // Start is called before the first frame update
    void Start()
    {

        kupione1 = zmienna.poziom2;

        kupione2 = zmienna.poziom3;
        kupione3 = zmienna.poziom4;
        kupione4 = zmienna.poziom5;
        kupione5 = zmienna.poziom6;
    }
    void Update()
    {

        kupione1 = zmienna.poziom2;

        kupione2 = zmienna.poziom3;
        kupione3 = zmienna.poziom4;
        kupione4 = zmienna.poziom5;
        kupione5 = zmienna.poziom6;
        if (kupione1)
        {
            blokada[0].SetActive(false);
        }
        else
        {
            blokada[0].SetActive(true);
        }
           if(kupione2)
        {
            blokada[1].SetActive(false);
        }else
        {
            blokada[1].SetActive(true);
        }
        if (kupione3)
        {
            blokada[2].SetActive(false);
        }
        else
        {
            blokada[2].SetActive(true);
        }
        if (kupione4)
        {
            blokada[3].SetActive(false);
        }
        else
        {
            blokada[3].SetActive(true);
        }
        if (kupione5)
        {
            blokada[4].SetActive(false);
        }
        else
        {
            blokada[4].SetActive(true);
        }

    }
    public void Click1()
    {

        if (kupione1)
        {
            Game.SetActive(false);
            GameObject.SetActive(true);
            scenaAsy.LoadNextScene();
        }
        else
        {
            kup.SetActive(true);
            if (cena < zmienna.wynik)
            {
                tak.interactable = true;
            }
            else
            {
                tak.interactable = false;
            }

        }
    }
    public void Click2()
    {



        if (kupione2)
        {
            Game.SetActive(false);
            GameObject.SetActive(true);
            scenaAsy.LoadNextScene();
        }
        else
        {
            
            kup.SetActive(true);
            if (cena < zmienna.wynik)
            {
                tak.interactable = true;
            }
            else
            {
                tak.interactable = false;
            }
        }


    }
    public void Click3()
    {



        if (kupione3)
        {
            Game.SetActive(false);
            GameObject.SetActive(true);
            scenaAsy.LoadNextScene();
        }
        else
        {

            kup.SetActive(true);
            if (cena < zmienna.wynik)
            {
                tak.interactable = true;
            }
            else
            {
                tak.interactable = false;
            }
        }


    }

    public void Click4()
    {



        if (kupione4)
        {
            Game.SetActive(false);
            GameObject.SetActive(true);
            scenaAsy.LoadNextScene();
        }
        else
        {

            kup.SetActive(true);
            if (cena < zmienna.wynik)
            {
                tak.interactable = true;
            }
            else
            {
                tak.interactable = false;
            }
        }


    }
    public void Click5()
    {



        if (kupione5)
        {
            Game.SetActive(false);
            GameObject.SetActive(true);
            scenaAsy.LoadNextScene();
        }
        else
        {

            kup.SetActive(true);
            if (cena < zmienna.wynik)
            {
                tak.interactable = true;
            }
            else
            {
                tak.interactable = false;
            }
        }


    }

    public void kupto()
    {
        if (cena <= zmienna.wynik)
        {
            zmienna.wynik -= cena;
            text.zmianakasy();
            if (j == 1)
            {
                zmienna.poziom2 = true;

            }
            if (j == 2)
            {
                zmienna.poziom3 = true;

            }
            if (j == 3)
            {
                zmienna.poziom4 = true;

            }
            if (j == 4)
            {
                zmienna.poziom5 = true;

            }
            if (j == 5)
            {
                zmienna.poziom6 = true;

            }
        }

    }
    public void setj(int i)
    {
        j = i;
    }
}