using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour
{
    public GameObject questionPanel;

    public void OpenQuestionPanel()
    {
        questionPanel.SetActive(true);
    }
    public void CloseQuestionPanel()
    {
        questionPanel.SetActive(false);
    }

    public void ReturnMainScene()
    {
        // Sahneyi yeniden yükle
        SceneManager.LoadScene("MainScene");
    }
}
