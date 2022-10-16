using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI text;

    private float value;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        value += Time.deltaTime;

        TimeSpan time = TimeSpan.FromSeconds(value);

        string str = time.ToString(@"mm\:ss");

        var minutes = value / 60;
        var seconds = (value % 60) / 100;

        text.text = str;
    }
}

