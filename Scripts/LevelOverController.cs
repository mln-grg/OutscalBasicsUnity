using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            int totalscenes = SceneManager.sceneCountInBuildSettings;
            int nextscene = SceneManager.GetActiveScene().buildIndex + 1;
            if(nextscene < totalscenes)
            {
                SceneManager.LoadScene(nextscene);
            }
            else
            {
                Debug.Log("Game Over");
            }

        }
    }
}
