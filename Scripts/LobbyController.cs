using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    
    public Button StartButton;
    private void Awake()
    {
        StartButton.onClick.AddListener(StartGame);
    }
    private void StartGame()
    {    
        SceneManager.LoadScene(1);
    }
}
