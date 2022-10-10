using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStats : MonoBehaviour
{
    public Slider healthSlider;
    public TextMeshProUGUI healthText;

    private void Awake()
    {
    }

    private void Start()
    {
        Player.Instance.Entity.onHealthChanged += UpdateUI;
        UpdateUI();
    }

    public void UpdateUI()
    {
        var health = Player.Instance.Entity.Health / (float)Player.Instance.Entity.MaxHealth;

        healthSlider.value = health;
        healthText.text = $"Health: {(int)(health * 100)}%";
    }
}

