using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public Button RestartButton;
    public Button MainMenuButton;

    private void Awake()
    {
        RestartButton.onClick.AddListener(ReloadLevel);
        MainMenuButton.onClick.AddListener(MainMenu);
    }
    public void GameOver()
    {
        gameObject.SetActive(true);
    }
    private void ReloadLevel()
    {
        int level;
        level = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(level);
    }
    private void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
