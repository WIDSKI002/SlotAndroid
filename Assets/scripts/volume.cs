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
            // Ustaw g�o�no�� dla ka�dego d�wi�ku
            UstawGlosnosc(dzwiek1, zmienna.volume); // 0.5 to poziom g�o�no�ci (od 0 do 1)
        }
        else
        {
            UstawGlosnosc(dzwiek1, zmienna.volume2);
        }

    }

    void UstawGlosnosc(AudioSource audioSource, float poziomGlosnosci)
    {
        // Upewnij si�, �e audioSource nie jest null
        if (audioSource != null)
        {
            // Ustaw g�o�no��
            audioSource.volume = Mathf.Clamp01(poziomGlosnosci); // Zapewnia, �e g�o�no�� jest w zakresie od 0 do 1
        }
        else
        {
            Debug.LogError("AudioSource jest null.");
        }
    }
}
