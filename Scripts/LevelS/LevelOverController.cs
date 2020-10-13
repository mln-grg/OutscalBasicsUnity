using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    public GameOverController gameovercontroller;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            int maxScenes = SceneManager.sceneCountInBuildSettings;
            if (SceneManager.GetActiveScene().buildIndex != maxScenes)
            {
                Debug.Log("levelcompleted");
                LevelManager.Instance.MarkLevelCompleted();
            }
            else
            {
                gameovercontroller.GameOver();
            }

        }
    }
}
