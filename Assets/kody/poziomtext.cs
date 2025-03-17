using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class poziomtext : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private scena_asy[] scena;
    [SerializeField] private check[] checkk;
    [SerializeField] private int j;
    void Start()
    {
        j = check.j;
        if (j ==1)
        scoreText.text = "CZY CHCESZ KUPIÆ  " + scena[0].nextSceneName + " ZA : " + checkk[0].cena;
        if (j == 2)
            scoreText.text = "CZY CHCESZ KUPIÆ  " + scena[1].nextSceneName + " ZA : " + checkk[1].cena;
        if (j == 3)
            scoreText.text = "CZY CHCESZ KUPIÆ  " + scena[2].nextSceneName + " ZA : " + checkk[2].cena;
        if (j == 4)
            scoreText.text = "CZY CHCESZ KUPIÆ  " + scena[3].nextSceneName + " ZA : " + checkk[3].cena;
        if (j == 5)
            scoreText.text = "CZY CHCESZ KUPIÆ  " + scena[4].nextSceneName + " ZA : " + checkk[4].cena;
    }
    void Update()
    {
        j = check.j;
        if (j == 1)
            scoreText.text = "CZY CHCESZ KUPIÆ  " + scena[0].nextSceneName + " ZA : " + checkk[0].cena;
        if (j == 2)
            scoreText.text = "CZY CHCESZ KUPIÆ  " + scena[1].nextSceneName + " ZA : " + checkk[1].cena;
        if (j == 3)
            scoreText.text = "CZY CHCESZ KUPIÆ  " + scena[2].nextSceneName + " ZA : " + checkk[2].cena;
        if (j == 4)
            scoreText.text = "CZY CHCESZ KUPIÆ  " + scena[3].nextSceneName + " ZA : " + checkk[3].cena;
        if (j == 5)
            scoreText.text = "CZY CHCESZ KUPIÆ  " + scena[4].nextSceneName + " ZA : " + checkk[4].cena;
    }
   
}
