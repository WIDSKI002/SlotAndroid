using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class scena_asy : MonoBehaviour
{
    [SerializeField] public string nextSceneName; // Nazwa nastêpnej sceny
    [SerializeField] private Slider loadingSlider; // Przypisz pasek postêpu z Unity UI
    [SerializeField] private Text loadingText; // Przypisz tekst postêpu z Unity UI
    [SerializeField] private float delayBeforeLoading = 0.8f; // Dodatkowe opóŸnienie przed zakoñczeniem ³adowania
    [SerializeField] private float progressBarSpeed = 1000f; // Prêdkoœæ, z jak¹ pasek ³adowania siê aktualizuje

    public void LoadNextScene()
    {
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        loadingSlider.interactable = false;
        float targetProgress = 0f; // Celowy postêp ³adowania

        yield return new WaitForSeconds(delayBeforeLoading); // Oczekiwanie przed rozpoczêciem ³adowania

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nextSceneName);

        while (!asyncLoad.isDone)
        {
            targetProgress = asyncLoad.progress; // Ustawienie celowego postêpu ³adowania

            // P³ynne zwiêkszanie postêpu ³adowania w kierunku celowego postêpu
            loadingSlider.value = Mathf.MoveTowards(loadingSlider.value, targetProgress, Time.deltaTime * progressBarSpeed);

            loadingText.text = "£adowanie: " + (loadingSlider.value * 100f).ToString("F0") + "%";

            yield return null;
        }
    }
}
