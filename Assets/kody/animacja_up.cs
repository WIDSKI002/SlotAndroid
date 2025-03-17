using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class animacja_up : MonoBehaviour
{
    [SerializeField] private Transform targetObject;
    [SerializeField] private float speed = 5f;
    [SerializeField] private Button myButton;
    [SerializeField] public bool isMoving = false;
    [SerializeField] public bool dodano = false;
    [SerializeField] private GameObject animacjaupp;
    private Vector3 pozycja; // Poprawiono na Vector3
    [SerializeField] private AudioSource audioSource;
    void Start()
    {
        // Zapisz aktualn¹ pozycjê obiektu
        pozycja = transform.position;
    
            myButton.onClick.AddListener(MoveObject);
     
 
       


    }
  
    void Update()
    {
        if (isMoving)
        {

            // Przesuwaj obiekt w kierunku targetObject
            transform.position = Vector3.MoveTowards(transform.position, targetObject.position, speed * Time.deltaTime);

            // SprawdŸ, czy obiekt dotar³ do targetObject
            if (Vector3.Distance(transform.position, targetObject.position) < 0.1f)
            {
                audioSource.Play();
                // Resetuj pozycjê obiektu
                ResetObjectPosition();
            }
        }
    }

    public void MoveObject()
    {
        // Ustaw isMoving na true po klikniêciu przycisku
        isMoving = true;
    }

    void ResetObjectPosition()
    {
 
        // Resetuj pozycjê obiektu i ustaw isMoving na false
        transform.position = pozycja; // Ustaw pozycjê na zapisan¹ wczeœniej wartoœæ
        isMoving = false;
        animacjaupp.SetActive(false);
    }
}
