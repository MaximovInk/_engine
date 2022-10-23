using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    public WeaponsDatabase WeaponDatabase;
    public AbilityDatabase AbilityDatabase;

    private void Awake()
    {
        if (Instance != null && Instance!=this) Destroy(gameObject);

        SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
        DontDestroyOnLoad(gameObject);
    }

    private void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
    {
        Time.timeScale = 1f;
        if(Player.Instance != null)
        {
            Player.Instance.Entity.onDead += Restart;
            Pause.Instance.StopPause();
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


}
