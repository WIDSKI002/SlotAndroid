using System;
using UnityEngine;
using UnityEngine.UI;

public class Cebuliony : MonoBehaviour
{
    [SerializeField] private Text timeText;
    [SerializeField] private Button clickButton;
    [SerializeField] private float cooldownTime = 6 * 60 * 60;

    [SerializeField] private DateTime currentTime;
    [SerializeField] private TimeSpan cooldownTimeSpan;
    [SerializeField] private text text;
    private void Awake()
    {
        // Cache components
        if (timeText == null)
            timeText = GetComponent<Text>();

        if (clickButton == null)
            clickButton = GetComponent<Button>();
    }

    private void Start()
    {
        currentTime = DateTime.Now;
        cooldownTimeSpan = TimeSpan.FromSeconds(cooldownTime);

        UpdateTimeText();
        clickButton.onClick.AddListener(OnClick);
        StartCoroutine(UpdateTimer());
    }

    private System.Collections.IEnumerator UpdateTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            currentTime += TimeSpan.FromSeconds(1);
            UpdateTimeText();
        }
    }

    private void OnClick()
    {
        if (CanClick())
        {
            DodajDoZmiennej(500);
            zmienna.time = DateTime.Now;
        }
    }

    private void DodajDoZmiennej(int wartosc)
    {
     
        zmienna.wynik += wartosc;
        text.zmianakasy();
    }

    private void UpdateTimeText()
    {
        TimeSpan timeRemaining = zmienna.time + cooldownTimeSpan - currentTime;

        // Use a conditional check instead of TimeSpan.Max
        if (timeRemaining.TotalSeconds < 0)
        {
            timeRemaining = TimeSpan.Zero;
        }

        timeText.text = (timeRemaining.TotalSeconds == 0)
            ? "CEBULIONY"
            : $"{timeRemaining.Hours:D2}:{timeRemaining.Minutes:D2}:{timeRemaining.Seconds:D2}";
    }

    private bool CanClick()
    {
        TimeSpan timePassed = currentTime - zmienna.time;
        return timePassed >= cooldownTimeSpan;
    }

    private void OnDisable()
    {
        clickButton.onClick.RemoveListener(OnClick);
    }
}
