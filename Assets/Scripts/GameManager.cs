using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void RestartScene()
    {
        // Sahneyi yeniden y�kle
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
