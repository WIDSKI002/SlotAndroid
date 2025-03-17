using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class coin_spin : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private Button clickButton;
   
    // Start is called before the first frame update
    void Start()
    {
        clickButton.onClick.AddListener(OnClick);
    }
    void OnClick()
    {
        bool isTrue = animator.GetBool("isWin");
        if (isTrue)
        {

            StartCoroutine(Delay(2.0f));
        }
        else
        {
            animator.SetBool("isWin", true);
        }

        
    }

        IEnumerator Delay(float delayTime)
    {

        yield return new WaitForSeconds(delayTime);

        animator.SetBool("isWin", false);

    }
}
