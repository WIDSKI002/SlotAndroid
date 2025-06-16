using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;

public class money_score : MonoBehaviour
{
    [SerializeField] private Text[] scoreText;
    [SerializeField] private int win1 = 10;
    [SerializeField] private int win2 = 50;
    [SerializeField] private int win3 = 10;
    [SerializeField] private int win4 = 100;
    [SerializeField] private int win5 = 200;

    // Start is called before the first frame update
    void Start()
    {
       
        scoreText[0].text = "" +(win1 * zmienna.mnoznik).ToString();
        scoreText[1].text = "" + (win2 * zmienna.mnoznik).ToString();
        scoreText[2].text = "" + (win4 * zmienna.mnoznik).ToString();
        scoreText[3].text = "" + (win5 * zmienna.mnoznik).ToString();
        scoreText[4].text = "CEBULIADA: " + win3.ToString();

       
      
        
      
    }

    // Update is called once per frame
    public void tabelawartosci()
    {
        scoreText[0].text = "" + (win1 * zmienna.mnoznik).ToString();
        scoreText[1].text = "" + (win2 * zmienna.mnoznik).ToString();
        scoreText[2].text = "" + (win4 * zmienna.mnoznik).ToString();
        scoreText[3].text = "" + (win5 * zmienna.mnoznik).ToString();

    }

  
}
