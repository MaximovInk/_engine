using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Button Vsync;
    private TextMeshProUGUI _vsyncText;

    public Transform MusicVolume;
    private Slider _musicSlider;
    private TextMeshProUGUI _musicText;

    public Transform FXVolume;
    private Slider _fxSlider;
    private TextMeshProUGUI _fxText;

    private void Awake()
    {
        _vsyncText = Vsync.GetComponentInChildren<TextMeshProUGUI>();

        _musicSlider = MusicVolume.GetComponentInChildren<Slider>();
        _musicText = MusicVolume.GetComponentsInChildren<TextMeshProUGUI>()[1];

        _fxSlider = FXVolume.GetComponentInChildren<Slider>();
        _fxText = FXVolume.GetComponentsInChildren<TextMeshProUGUI>()[1];

        Vsync.onClick.AddListener(VsyncToggle);

        _musicSlider.onValueChanged.AddListener(MusicVolumeChanged);
        _fxSlider.onValueChanged.AddListener(FXVolumeChanged);
    }

    public void MusicVolumeChanged(float value)
    {
        GameManager.Instance.settingsData.musicVolume = value;
        UpdateUI();
        GameManager.Instance.UpdateVolume();
    }

    public void FXVolumeChanged(float value)
    {
        GameManager.Instance.settingsData.fxVolume = value;
        UpdateUI();
        GameManager.Instance.UpdateVolume();
    }

    public void VsyncToggle()
    {
        Application.targetFrameRate = (Application.targetFrameRate == -1 ? 60 : -1);
        UpdateUI();
    }

    private void OnEnable()
    {
        UpdateUI();

        _musicSlider.value = GameManager.Instance.settingsData.musicVolume;
        _fxSlider.value = GameManager.Instance.settingsData.fxVolume;
    }

    public void UpdateUI()
    {
        var isVsync = Application.targetFrameRate != -1;

        _vsyncText.text = $"VSync: " + (isVsync?"60" : "Off");

        _musicText.text = $"{(int)(GameManager.Instance.settingsData.musicVolume * 100f)}%";
        
        _fxText.text = $"{(int)(GameManager.Instance.settingsData.fxVolume * 100f)}%";
    }
}
