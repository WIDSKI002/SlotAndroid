using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class scena_asy : MonoBehaviour
{
    [SerializeField] public string nextSceneName; // Nazwa nast�pnej sceny
    [SerializeField] private Slider loadingSlider; // Przypisz pasek post�pu z Unity UI
    [SerializeField] private Text loadingText; // Przypisz tekst post�pu z Unity UI
    [SerializeField] private float delayBeforeLoading = 0.8f; // Dodatkowe op�nienie przed zako�czeniem �adowania
    [SerializeField] private float progressBarSpeed = 1000f; // Pr�dko��, z jak� pasek �adowania si� aktualizuje

    public void LoadNextScene()
    {
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        loadingSlider.interactable = false;
        float targetProgress = 0f; // Celowy post�p �adowania

        yield return new WaitForSeconds(delayBeforeLoading); // Oczekiwanie przed rozpocz�ciem �adowania

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nextSceneName);

        while (!asyncLoad.isDone)
        {
            targetProgress = asyncLoad.progress; // Ustawienie celowego post�pu �adowania

            // P�ynne zwi�kszanie post�pu �adowania w kierunku celowego post�pu
            loadingSlider.value = Mathf.MoveTowards(loadingSlider.value, targetProgress, Time.deltaTime * progressBarSpeed);

            loadingText.text = "�adowanie: " + (loadingSlider.value * 100f).ToString("F0") + "%";

            yield return null;
        }
    }
}
