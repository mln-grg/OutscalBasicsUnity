using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    public Button StartButton;
    public GameObject levelSelectionPopup;
    private void Awake()
    {
        StartButton.onClick.AddListener(StartGame);
    }
    private void StartGame()
    {
        levelSelectionPopup.SetActive(true);
    }
}
