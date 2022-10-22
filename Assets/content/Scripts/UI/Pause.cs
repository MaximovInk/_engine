using UnityEngine;

public class Pause : MonoBehaviourSingletonAuto<Pause>
{
    private float timeScaleSaved = 1f;

    public bool IsPause
    {
        get => _isPause;
        set {
            _isPause = value;

            if (_isPause)
            {
                timeScaleSaved = Time.timeScale;
                Time.timeScale = 0;
            }
            else
                Time.timeScale = timeScaleSaved;
        }
    }

    private bool _isPause;

    private GameObject _fade;

    private void Awake()
    {
        _fade = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            ActivatePause();     
    }

    public void GoToMenu()
    {
        GameManager.Instance.GoToMenu();
    }

    public void ActivatePause()
    {
        _fade.SetActive(true);
        HudController.Instance.Hide();
        IsPause = true;
    }

    public void StopPause()
    {
        _fade.SetActive(false);
        HudController.Instance.Show();
        IsPause = false;
    }
}
