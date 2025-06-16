using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class takkup : MonoBehaviour
{
    [SerializeField] private Button clickButton;
    [SerializeField] private int j;
    [SerializeField] private GameObject[] game;
    // Start is called before the first frame update
    void Start()
    {
       
        clickButton.onClick.AddListener(OnClick);
        
    }
    void OnClick()
    {
        j = check.j;
        if (j == 1)
        {
            check customScript = game[0].GetComponent<check>();

            if (customScript != null)
            {
                customScript.kupto();
            }
            else
            {
                Debug.LogError("CustomScript component not found on the GameObject!");
            }
        }
        if (j == 2)
        {
            check customScript = game[1].GetComponent<check>();

            if (customScript != null)
            {
                customScript.kupto();
            }
            else
            {
                Debug.LogError("CustomScript component not found on the GameObject!");
            }
        }
        if (j == 3)
        {
            check customScript = game[2].GetComponent<check>();

            if (customScript != null)
            {
                customScript.kupto();
            }
            else
            {
                Debug.LogError("CustomScript component not found on the GameObject!");
            }
        }
        if (j == 4)
        {
            check customScript = game[3].GetComponent<check>();

            if (customScript != null)
            {
                customScript.kupto();
            }
            else
            {
                Debug.LogError("CustomScript component not found on the GameObject!");
            }
        }
        if (j == 5)
        {
            check customScript = game[4].GetComponent<check>();

            if (customScript != null)
            {
                customScript.kupto();
            }
            else
            {
                Debug.LogError("CustomScript component not found on the GameObject!");
            }
        }
    }
     
}
