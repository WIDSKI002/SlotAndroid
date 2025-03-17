using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volume : MonoBehaviour
{
    [SerializeField] private AudioSource dzwiek1;
    [SerializeField] private bool dziwek = false;

    void Start()
    {
        if (!dziwek)
        {
            // Ustaw g³oœnoœæ dla ka¿dego dŸwiêku
            UstawGlosnosc(dzwiek1, zmienna.volume); // 0.5 to poziom g³oœnoœci (od 0 do 1)
        }
        else
        {
            UstawGlosnosc(dzwiek1, zmienna.volume2);
        }

    }

    void UstawGlosnosc(AudioSource audioSource, float poziomGlosnosci)
    {
        // Upewnij siê, ¿e audioSource nie jest null
        if (audioSource != null)
        {
            // Ustaw g³oœnoœæ
            audioSource.volume = Mathf.Clamp01(poziomGlosnosci); // Zapewnia, ¿e g³oœnoœæ jest w zakresie od 0 do 1
        }
        else
        {
            Debug.LogError("AudioSource jest null.");
        }
    }
}
