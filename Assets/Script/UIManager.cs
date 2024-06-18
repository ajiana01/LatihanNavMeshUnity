using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] public Button playButton, exitButton;
    void Start()
    {
        playButton.onClick.AddListener(ChangeScene);
        exitButton.onClick.AddListener(Exit);
    }

    // Update is called once per frame
    void Exit()
    {
        Application.Quit();
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("Gameplay Scene");
    }
}
