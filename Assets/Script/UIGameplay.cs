using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIGameplay : MonoBehaviour
{
    [SerializeField] public Button restartButton, mainMenuButton;

    [SerializeField] public GameObject gameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        restartButton.onClick.AddListener(Restart);
        mainMenuButton.onClick.AddListener(MainMenu);
        Time.timeScale = 1;
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    void MainMenu()
    {
        SceneManager.LoadScene("Main Menu Scene");
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
