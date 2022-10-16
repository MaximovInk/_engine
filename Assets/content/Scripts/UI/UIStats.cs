using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStats : MonoBehaviourSingleton<UIStats>
{
    [SerializeField]
    private Slider healthSlider;
    [SerializeField]
    private TextMeshProUGUI healthText;
    [SerializeField]
    private Slider experienceSlider;
    [SerializeField]
    private TextMeshProUGUI lvlText;
    [SerializeField]
    private TextMeshProUGUI enemyDeathCountText;

    private void Start()
    {
        Player.Instance.Entity.onHealthChanged += UpdateUI;
        LevelManager.Instance.LevelData.OnChanged += (_) 
            => UpdateUI();

        UpdateUI();
    }

    public void UpdateUI()
    {
        var health = Player.Instance.Entity.Health / (float)Player.Instance.Entity.MaxHealth;

        healthSlider.value = health;
        healthText.text = $"Health: {(int)(health * 100)}%";

        experienceSlider.value 
            = LevelManager.Instance.LevelCounter
            .GetExperienceRelative(LevelManager.Instance.LevelData);

        lvlText.text = $"{LevelManager.Instance.LevelData.Level} lvl";

        enemyDeathCountText.text = LevelManager.Instance.LevelData.EnemyDeathCount.ToString();

    }
}

