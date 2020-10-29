using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Button))]
public class StartButton : MonoBehaviour
{
    private Button button;
    public string LevelName;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }
    public void setLevelName(string name)
    {
        LevelName = name;
        Debug.Log(LevelName);
    }
    private void onClick()
    {
        Debug.Log(LevelName);
        FindObjectOfType<SoundManager>().Play("GameStart");
        SceneManager.LoadScene(LevelName);

    }
}
