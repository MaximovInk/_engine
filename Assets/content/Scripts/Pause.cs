using UnityEngine;

public class Pause : MonoBehaviourSingletonAuto<Pause>
{
    public bool isPause = false;

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
        isPause = true;
        Time.timeScale = 0;
    }

    public void StopPause()
    {
        _fade.SetActive(false);
        HudController.Instance.Show();
        isPause = false;
        Time.timeScale = 1;
    }
}
