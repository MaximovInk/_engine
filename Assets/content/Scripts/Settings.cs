using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Button Vsync;
    private TextMeshProUGUI _vsyncText;

    private void Awake()
    {
        _vsyncText = Vsync.GetComponentInChildren<TextMeshProUGUI>();

        Vsync.onClick.AddListener(VsyncToggle);
    }

    public void VsyncToggle()
    {
        Application.targetFrameRate = (Application.targetFrameRate == -1 ? 60 : -1);
        UpdateUI();
    }

    private void OnEnable()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        var isVsync = Application.targetFrameRate != -1;

        _vsyncText.text = $"VSync: " + (isVsync?"60" : "Off");
    }
}
