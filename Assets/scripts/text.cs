using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text : MonoBehaviour
{
    [SerializeField] private Text scoreText; // Referencja do pola tekstowego

    // Start is called before the first frame update
    void Start()
    {
        if(zmienna.wynik == 0)
        {
            scoreText.text = "CEBULIONY: 0";
        }
        else{
        
        string sformatowanaLiczba = string.Format("{0:#,###}", zmienna.wynik);
    
        scoreText.text = "CEBULIONY: " + sformatowanaLiczba.ToString();}
    }

    // Update is called once per frame
   public  void zmianakasy()
    {

   if(zmienna.wynik == 0)
        {
            scoreText.text = "CEBULIONY: 0";
        }
        else{
        string sformatowanaLiczba = string.Format("{0:#,###}", zmienna.wynik);

        scoreText.text = "CEBULIONY: " + sformatowanaLiczba.ToString();
        }

    }
}
