
using UnityEngine;
using UnityEngine.UI;

public class slider : MonoBehaviour
{
    [SerializeField] private Slider sliderr;
    [SerializeField] private Slider sliderr2;

    void Start()
    {
        // Ustaw domy�ln� warto�� slidera i g�o�no�ci
        // volumeSlider.value = audioSource.volume;
        sliderr.value = zmienna.volume;
        sliderr2.value = zmienna.volume2;
    }
    void Update()
    {
        // Pobierz aktualn� warto�� z Slidera
        zmienna.volume = sliderr.value;
        zmienna.volume2 = sliderr2.value;
    }
    
}
