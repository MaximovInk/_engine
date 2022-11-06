using UnityEngine;
using UnityEngine.SceneManagement;

public struct SettingsData
{
    public float musicVolume;
    public float fxVolume;
}

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    public WeaponsDatabase WeaponDatabase;
    public AbilityDatabase AbilityDatabase;

    public SettingsData settingsData;

    public AudioSource MainSource => _menuSource;

    private AudioSource _menuSource;

    private void Awake()
    {
        _menuSource = GetComponent<AudioSource>();

        settingsData = new SettingsData { fxVolume = 0.33f, musicVolume = 0.33f };

        UpdateVolume();

        if (Instance != null && Instance!=this) Destroy(gameObject);

        SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
        DontDestroyOnLoad(gameObject);
    }

    private void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
    {
        Time.timeScale = 1f;

        if(Player.Instance != null)
        {
            Player.Instance.Entity.onDead += () => { SceneManager.LoadScene(0); };
            Pause.Instance.StopPause();
            _menuSource.Pause();
        }
        else
        {
            _menuSource.Play();
        }
    }

    public void Restart()
    {
        Continue();
    }

    public void Continue()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToMenu()
    {
        Player.Instance.Entity.onDead -= Restart;
        SceneManager.LoadScene(0);
    }

    public void UpdateVolume()
    {
        _menuSource.volume = settingsData.musicVolume;
    }
}
