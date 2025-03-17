
using UnityEngine;
using UnityEngine.UI;

public class slider : MonoBehaviour
{
    [SerializeField] private Slider sliderr;
    [SerializeField] private Slider sliderr2;

    void Start()
    {
        // Ustaw domyœln¹ wartoœæ slidera i g³oœnoœci
        // volumeSlider.value = audioSource.volume;
        sliderr.value = zmienna.volume;
        sliderr2.value = zmienna.volume2;
    }
    void Update()
    {
        // Pobierz aktualn¹ wartoœæ z Slidera
        zmienna.volume = sliderr.value;
        zmienna.volume2 = sliderr2.value;
    }
    
}
