
using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class zmienna : MonoBehaviour
{
    public static int wynik;
    public static System.DateTime time;
    public static float volume;
    public static float volume2;
    public static int mnoznik = 1;
    public static int wartosc = 1;
    public static bool poziom2 = false;
    public static bool poziom3 = false;
    public static bool poziom4 = false;
    public static bool poziom5 = false;
    public static bool poziom6 = false;
    public void OnApplicationQuit()
    {

        // Zapisywanie zmiennej do pliku przy zamykaniu gry
        string filePath = Application.persistentDataPath + "/Wynik.txt";
        string[] lines = { wynik.ToString(), time.ToString(), volume.ToString(), volume2.ToString(), poziom2.ToString(), poziom3.ToString(), poziom4.ToString(), poziom5.ToString(), poziom6.ToString() };
        File.WriteAllLines(filePath, lines);
    }
    private void OnApplicationPause()
    {

        // Zapisywanie zmiennej do pliku przy zamykaniu gry
        string filePath = Application.persistentDataPath + "/Wynik.txt";
        string[] lines = { wynik.ToString(), time.ToString(), volume.ToString(), volume2.ToString(), poziom2.ToString(), poziom3.ToString(), poziom4.ToString(), poziom5.ToString(), poziom6.ToString() };
        File.WriteAllLines(filePath, lines);

    }
    private void Awake()
    {
        // Sprawdzanie istnienia pliku przed odczytem
        string filePath = Application.persistentDataPath + "/Wynik.txt";
        Debug.Log("Œcie¿ka do pliku: " + filePath);

        if (File.Exists(filePath))
        {
            // Odczytywanie zmiennych z pliku, jeœli istnieje
            string[] lines = File.ReadAllLines(filePath);

            // Sprawdzenie czy ka¿da linia zawiera dane
            for (int i = 0; i < lines.Length; i++)
            {
                if (string.IsNullOrEmpty(lines[i]))
                {
                    // Brakuj¹ce dane - uzupe³nij wartoœciami domyœlnymi
                    switch (i)
                    {
                        case 0:
                            wynik = 2000;
                            break;
                        case 1:
                            // Set the default date and time to '28.12.2022 12:43:59'
                            string defaultDate = "28.12.2022 12:43:59";
                            time = System.DateTime.ParseExact(defaultDate, "dd.MM.yyyy HH:mm:ss", null);
                            break;
                        case 2:
                        case 3:
                            // Set default volume values
                            volume = 0.6625689f;
                            volume2 = 0.6625689f;
                            break;
                        case 4:
                        case 5:
                            poziom2 = false;
                            poziom3 = false;
                            poziom4 = false;
                            poziom5 = false;
                            poziom6 = false;
                            break;
                        default:
                            Debug.LogError("Unknown line in the file.");
                            break;
                    }
                }
                else
                {
                    // Dane istniej¹ - wczytaj wartoœci
                    switch (i)
                    {
                        case 0:
                            wynik = int.Parse(lines[i]);
                            break;
                        case 1:
                            time = System.DateTime.Parse(lines[i]);
                            break;
                        case 2:
                            volume = float.Parse(lines[i]);
                            break;
                        case 3:
                            volume2 = float.Parse(lines[i]);
                            break;
                        case 4:
                            poziom2 = bool.Parse(lines[i]);
                            break;
                        case 5:
                            poziom3 = bool.Parse(lines[i]);
                            break;
                        case 6:
                            poziom4 = bool.Parse(lines[i]);
                            break;
                        case 7:
                            poziom5 = bool.Parse(lines[i]);
                            break;
                        case 8:
                            poziom6 = bool.Parse(lines[i]);
                            break;
                        default:
                            Debug.LogError("Unknown line in the file.");
                            break;
                    }
                }
            }
        }
        else
        {
            // Jeœli plik nie istnieje, tworzymy go i zapisujemy wartoœæ domyœln¹
            wynik = 2000; // Ustawienie domyœlnej wartoœci

            // Set the default date and time to '28.12.2022 12:43:59'
            string defaultDate = "28.12.2022 12:43:59";
            time = System.DateTime.ParseExact(defaultDate, "dd.MM.yyyy HH:mm:ss", null);

            volume = 0.6625689f;
            volume2 = 0.6625689f;
            poziom2 = false;
            poziom3 = false;
            poziom4 = false;
            poziom5 = false;
            poziom6 = false;
            string[] defaultLines = { wynik.ToString(), time.ToString("dd.MM.yyyy HH:mm:ss"), volume.ToString(), volume2.ToString(), poziom2.ToString(), poziom3.ToString(), poziom4.ToString(), poziom5.ToString(), poziom6.ToString() };
            File.WriteAllLines(filePath, defaultLines);
        }
        QualitySettings.vSyncCount = 0;  // Wy³¹cza v-sync
        Application.targetFrameRate = 60;  // Ustawia docelowy FPS
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Menu) || Input.GetKeyDown(KeyCode.Home))
        {
            OnApplicationQuit();
        }

    }
}

