using UnityEngine;
using UnityEngine.UI;

public class AbilitesUI : MonoBehaviourSingleton<AbilitesUI>
{
    public Image[] slots;

    private void Awake()
    {
        LevelManager.Instance.AbilitesChanged += UpdateUI;
    }

    public void UpdateUI()
    {
        var abilites = LevelManager.Instance.LevelData.abilities;

        for (int i = 0; i < slots.Length; i++)
        {
            if(i >= abilites.Count)
            {
                slots[i].color = new Color(1f, 1f, 1f, 0.1f);
            }
            else
            {
                slots[i].color = Color.white;
                slots[i].sprite = abilites[i].GetIcon();
            }
        }
    }
}

