using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerChecker : MonoBehaviour
    {
    private void Awake()
    {
        if(GameManager.Instance == null && SceneManager.GetActiveScene().name != "Menu")
        {
            SceneManager.LoadScene(0);
        }
    }
}
