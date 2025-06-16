using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using static animacja_up;
public class spin : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Animator animator;
  
    [SerializeField] private GameObject[] gameObjects;
    [SerializeField] private GameObject[] animacjaupp;
    [SerializeField] private Sprite[] images;
    [SerializeField] private Button myButton;
    private int[,] grid = new int[3, 3];
    [SerializeField] private zmienna zmienna;
    [SerializeField] private animacja_up[] animacjaup;
    [SerializeField] public int freespin ;
    [SerializeField] public bool spinning = false;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Text timeText;
    bool jest = false;
    [SerializeField] private string tekstKomunikatu = "ZA MA£O CEBULIONÓW!";
    private bool wyswietlKomunikat = false;
    private List<GameObject> winningLineObjects = new List<GameObject>();
    [SerializeField] private int win1 = 10;
    [SerializeField] private int win2 = 50;
    [SerializeField] private int win3 = 10;
    [SerializeField] private int win4 = 100;
    [SerializeField] private int win5 = 200;

    [SerializeField] public int startcost = 5;

    [SerializeField] private text text;
    public void OnApplicationQuit()
    {
        DestroyAllWinningLines();
    }
    void Start()
    {
        timeText.text = "SPIN("+startcost* zmienna.mnoznik + ")";  
        InitializeGrid();
       // clickButton.onClick.AddListener(OnClick);
        for (int i = 0; i < 3; i++)
        {
                DrawLine(GetImagePosition(i, 0), GetImagePosition(i, 2));
             
        }
        DrawLine(GetImagePosition(0, 0), GetImagePosition(2, 2));
        DrawLine(GetImagePosition(0, 2), GetImagePosition(2, 0));
    }
    
    

    void FixedUpdate()
    {
        HandleFreeSpins();
      

    }
    void HandleFreeSpins()
    {
        bool isTrue = animator.GetBool("isWin");
        if (isTrue)
        {

            StartCoroutine(Delay(2.0f));
        }

        if (freespin > 0 && !spinning)
        {


            freespin--;
            timeText.text = "CEBULIADA(" + freespin + ")";

            DestroyAllWinningLines();
            StartCoroutine(SpinImagesCoroutine());
            spinning = true;
            audioSource.Play();
            wyswietlKomunikat = false;

            StartCoroutine(DelayedVoidMethodCoroutine(2.0f));

        }


    }
    public void OnPointerClick(PointerEventData eventData)
    {
       
        if (!spinning) { 
            if (zmienna.wynik >= (startcost * zmienna.mnoznik))
            {
                zmienna.wynik -= (startcost * zmienna.mnoznik);

                StartCoroutine(SpinImagesCoroutine());
                DestroyAllWinningLines();
                text.zmianakasy();
                audioSource.Play();
                wyswietlKomunikat = false;
              
            }
            else
            {
                wyswietlKomunikat = true;
            }
        }

    }
            void DestroyAllWinningLines()
    {
        
            foreach (GameObject lineObject in winningLineObjects)
            {
                lineObject.SetActive(false);
            }
        
    }

    void OnGUI()
    {
        if (wyswietlKomunikat)
        {
            GUIStyle style = new GUIStyle();
            style.fontSize = 100;
            style.normal.textColor = Color.white;

            GUI.Label(new Rect(400, 200, 400, 40), tekstKomunikatu, style);
        }
    }

    IEnumerator SpinImagesCoroutine()
    {
        spinning = true;
        int spins = Random.Range(10, 15);

        for (int i = 0; i < spins; i++)
        {
            SpinImages();
            yield return new WaitForSeconds(0.099f);
        }
       
        CalculatePoints();
        if (freespin == 0)
        {
            spinning = false;
        }
        
        yield return StartCoroutine(MoveImagesCoroutine());
    }

    void InitializeGrid()
    {
        RandomizeImages();
    }

   void RandomizeImages()
{
    int index = 0;

    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            grid[i, j] = generateRandomNumber(1);
            gameObjects[index].GetComponent<SpriteRenderer>().sprite = images[grid[i, j]];
            index++;
        }
    }
}

    void RandomizeImage()
    {
       
            grid[0, 0] = generateRandomNumber(1);
        grid[0, 1] = generateRandomNumber(2);
        grid[0, 2] = generateRandomNumber(3);
        UpdateImages();
    }

    void UpdateImages()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                int index = grid[i, j];
                GameObject go = gameObjects[i * 3 + j];
                SpriteRenderer spriteRenderer = go.GetComponent<SpriteRenderer>();

                if (spriteRenderer != null)
                {
                    spriteRenderer.sprite = images[index];
                }
            }
        }
    }

    void SpinImages()
    {
        int temp = grid[0, 0];
        int temp1 = grid[0, 1];
        int temp2 = grid[0, 2];

        grid[2, 0] = grid[1, 0];
        grid[2, 1] = grid[1, 1];
        grid[2, 2] = grid[1, 2];

        grid[1, 0] = temp;
        grid[1, 1] = temp1;
        grid[1, 2] = temp2;

        RandomizeImage();
    }

    IEnumerator MoveImagesCoroutine()
    {
        Vector3[] initialPositions = new Vector3[gameObjects.Length];
        for (int i = 0; i < gameObjects.Length; i++)
        {
            initialPositions[i] = gameObjects[i].transform.position;
        }

        Vector3[] targetPositions = new Vector3[gameObjects.Length];
        System.Array.Copy(initialPositions, targetPositions, gameObjects.Length);

        float elapsedTime = 0f;
        float duration = 0.098f;

        //while (elapsedTime < duration)
        //{
        //    for (int i = 0; i < gameObjects.Length; i++)
        //    {
        //        gameObjects[i].transform.position = Vector3.Lerp(initialPositions[i], targetPositions[i], elapsedTime / duration);
        //    }

        //    elapsedTime += Time.deltaTime;
        //    yield return null;
        //}
        while (elapsedTime < duration)
        {
            for (int i = 0; i < gameObjects.Length; i++)
            {
                float t = elapsedTime / duration;
                t = Mathf.SmoothStep(0.0f, 1.0f, t); // lub Mathf.LerpUnclamped(0.0f, 1.0f, t)
                gameObjects[i].transform.position = Vector3.Lerp(initialPositions[i], targetPositions[i], t);
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        System.Array.Copy(targetPositions, initialPositions, gameObjects.Length);

        if (freespin > 0 && !jest)
        {
            jest = true;
            spinning = false;
        }

        if (freespin == 0)
        {
            timeText.text = "SPIN(" + (startcost * zmienna.mnoznik) + ")";
            jest = false;
            DelayedVoidMethodCoroutine(0.5f);
        }
    }


    void CalculatePoints()
    {
        CheckRowMatches();
        CheckDiagonalMatches();
        DrawWinningLines();

        if (freespin > 0)
        {
            timeText.text = "CEBULIADA(" + freespin + ")";
        }
        else
        {
            myButton.interactable = true;
        }
    }

    void CheckRowMatches()
    {
        for (int i = 0; i < 3; i++)
        {
            if (grid[i, 0] == grid[i, 1] && grid[i, 1] == grid[i, 2])
            {
                HandleMatch(grid[i, 0]);
            }
        }
    }

    void CheckDiagonalMatches()
    {
        if (grid[0, 0] == grid[1, 1] && grid[1, 1] == grid[2, 2])
        {
            HandleMatch(grid[0, 0]);
        }

        if (grid[0, 2] == grid[1, 1] && grid[1, 1] == grid[2, 0])
        {
            HandleMatch(grid[0, 2]);
        }
    }

    void HandleMatch(int imageName)
    {
        if (imageName != 2)
        {
            animator.SetBool("isWin", true);
            AktywujAnimacjeDlaWszystkich();
            StartCoroutine(AnimacjaCoroutine((getScoreForImage(imageName) * zmienna.mnoznik) / animacjaup.Length));
        }
        else
        {
            myButton.interactable = false;
            freespin += getScoreForImage(imageName);
        }
    }
    void AktywujAnimacjeDlaWszystkich()
    {
        foreach (GameObject animacja in animacjaupp)
        {
            if (animacja != null)
            {
                animacja.SetActive(true);
            }
        }
        
            foreach (animacja_up animacija in animacjaup)
            {
               
                    if (animacija != null)
                    {
                        animacija.MoveObject();
                    }
                
                   
            }



    }



    public class AnimacjaCoroutineData
    {
        public bool isRunning;
        public int value;

        public AnimacjaCoroutineData(bool isRunning, int value)
        {
            this.isRunning = isRunning;
            this.value = value;
        }
    }

    // W twojej klasie, gdzie znajduje siê coroutine
    private Dictionary<int, AnimacjaCoroutineData> activeCoroutines = new Dictionary<int, AnimacjaCoroutineData>();

    private IEnumerator AnimacjaCoroutine(int wynn)
    {
        // SprawdŸ, czy coroutine z t¹ wartoœci¹ jest ju¿ aktywna
        if (activeCoroutines.ContainsKey(wynn))
        {
            // Coroutine z t¹ wartoœci¹ jest ju¿ aktywna, dodaj wartoœæ do siebie
            activeCoroutines[wynn].value += wynn;
        }
        else
        {
            // Coroutine z t¹ wartoœci¹ nie jest aktywna, uruchom coroutine
            activeCoroutines[wynn] = new AnimacjaCoroutineData(true, wynn);

            do
            {
                int k = 0;

                foreach (animacja_up animacja in animacjaup)
                {
                    if (animacja != null && animacja.isMoving == false)
                    {
                        ++k;

                        if (animacja.dodano == false)
                        {
                            zmienna.wynik += activeCoroutines[wynn].value;
                            animacja.dodano = true;
                            text.zmianakasy();
                        }

                        if (k == animacjaup.Length)
                        {
                            foreach (animacja_up animacjaa in animacjaup)
                            {
                                animacjaa.dodano = false;
                            }
                            activeCoroutines[wynn].isRunning = false;
                        }
                    }
                }
                
                yield return null;
            } while (activeCoroutines[wynn].isRunning);

            // Coroutine zakoñczona, usuñ z listy aktywnych coroutine
            activeCoroutines.Remove(wynn);
        }
    }


    IEnumerator DelayedVoidMethodCoroutine(float delayTime)
    {
       // Debug.Log(delayTime);
        yield return new WaitForSeconds(delayTime);

        spinning = false;

    }
    int getScoreForImage(int imageName)
    {
        switch (imageName)
        {
            case 0:
                return win1;
            case 1:
                return win2;
            case 2:
                return win3;
            case 3:
                return win4;
            case 4:
                return win5;
            default:
                return 0; // Domyœlna wartoœæ, jeœli imageName nie pasuje do ¿adnego przypadku.
        }
    }

    int generateRandomNumber(int rol)
    {
        int randomNumber = Random.Range(0, 100);
        if (rol == 1) { 
        switch (randomNumber)
        {
            case int n when n < 38:
                return 0;
            case int n when n < 58://58
                return 1;
            case int n when n < 75:
                return 2;
            case int n when n < 88:
                return 3;
            default:
                return 4;
        }
        }
        if (rol == 2)
        {
            switch (randomNumber)
            {
                case int n when n < 30:
                    return 0;
                case int n when n < 50://50
                    return 1;
                case int n when n < 68:
                    return 2;
                case int n when n < 88:
                    return 3;
                default:
                    return 4;
            }
        }
        if (rol == 3)
        {
            switch (randomNumber)
            {
                case int n when n < 30:
                    return 0;
                case int n when n < 45://45
                    return 1;
                case int n when n < 65:
                    return 2;
                case int n when n < 83:
                    return 3;
                default:
                    return 4;
            }
        }
        return 0;
    }


    void DrawWinningLines()
    {
        for (int i = 0; i < 3; i++)
        {
            if (grid[i, 0] == grid[i, 1] && grid[i, 1] == grid[i, 2])
            {
                ActivateLine(i);

                


            }
        }

        if (grid[0, 0] == grid[1, 1] && grid[1, 1] == grid[2, 2])
        {
            ActivateLine(3);
         


        }

        if (grid[0, 2] == grid[1, 1] && grid[1, 1] == grid[2, 0])
        {
            ActivateLine(4);
            


        }
    }

    void ActivateLine(int i)
    {
        // Przyjmujê, ¿e masz odpowiedni¹ listê obiektów winningLineObjects dostêpn¹

        
                winningLineObjects[i].SetActive(true);
             
        
    }

    Vector3 GetImagePosition(int row, int col)
    {
        GameObject go = gameObjects[row * 3 + col];
        return go.transform.position;
    }

  
    int lineCounter = 0;

    void DrawLine(Vector3 startPoint, Vector3 endPoint)
    {
        GameObject newWinningLineObject = new GameObject("WinningLine_" + lineCounter);
        lineCounter++;

        newWinningLineObject.AddComponent<LineRenderer>();
        LineRenderer lineRenderer = newWinningLineObject.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, startPoint);
        lineRenderer.SetPosition(1, endPoint);
        lineRenderer.startWidth = 1.0f;
        lineRenderer.endWidth = 1.0f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.material.mainTextureScale = new Vector2(1, 1);
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;
        lineRenderer.sortingLayerName = "YourSortingLayerName";
        lineRenderer.sortingOrder = 3;
        newWinningLineObject.SetActive(false);
        winningLineObjects.Add(newWinningLineObject);
    }
    IEnumerator Delay(float delayTime)
    {
       
        yield return new WaitForSeconds(delayTime);

        animator.SetBool("isWin", false);

    }
}
