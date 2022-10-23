using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUPSlot : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _title;
    [SerializeField]
    private TextMeshProUGUI _description;
    [SerializeField]
    private Image _icon;

    public AbilitySlot GetData() => _slotData;
    private AbilitySlot _slotData;

    public void SetData(AbilitySlot slot)
    {
        var button = GetComponent<Button>();

        _slotData = slot;

        var data = AbilitySlot.GetInfo(slot);

        _title.text = $"<- {data.Name} ->";
        _description.text = data.Description;
        _icon.sprite = data.Icon;

        button.onClick.AddListener(() => {
            LevelManager.Instance.AddAbility(slot);
            LevelUPPanel.Instance.Popup.Hide();
        });
    }
}

