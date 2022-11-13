using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviourSingleton<Timer>
{
    private TextMeshProUGUI text;

    private float value;

    public float Value => value;

    private float minuteCounter = 0f;

    public Action<int> OnMinuteElapsed;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        value += Time.deltaTime;
        minuteCounter += Time.deltaTime;
        if (minuteCounter >= 60)
        {
            minuteCounter = 0f;
            OnMinuteElapsed?.Invoke((int)(value / 60f));
        }

        TimeSpan time = TimeSpan.FromSeconds(value);

        string str = time.ToString(@"mm\:ss");

        var minutes = value / 60;
        var seconds = (value % 60) / 100;

        text.text = str;
    }
}

