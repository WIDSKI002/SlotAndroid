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

        string sformatowanaLiczba = string.Format("{0:#,###}", zmienna.wynik);
    
        scoreText.text = "CEBULIONY: " + sformatowanaLiczba.ToString();
    }

    // Update is called once per frame
   public  void zmianakasy()
    {


        string sformatowanaLiczba = string.Format("{0:#,###}", zmienna.wynik);

        scoreText.text = "CEBULIONY: " + sformatowanaLiczba.ToString();


    }
}
