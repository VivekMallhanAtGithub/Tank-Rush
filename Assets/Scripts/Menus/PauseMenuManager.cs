using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour
{
    public static PauseMenuManager Instance;

    private bool isGamePaused = false;
    public GameObject pauseMenuCanvas;
    public Button resumeButton;
    public Button quitButton;

    private void Awake()
    {
        if(Instance == null&& Instance != this)
        {
            Instance = this;
        }

        pauseMenuCanvas.SetActive(false);

        resumeButton.onClick.AddListener(() => ResumeButtonPressed());

        quitButton.onClick.AddListener(() => QuitButtonPressed());
    }

    public void ResumeButtonPressed()
    {
        isGamePaused = false;
        Time.timeScale = 1;

        pauseMenuCanvas.SetActive(false);
    }

    public void QuitButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");

        isGamePaused = false;
        Time.timeScale = 1;

        pauseMenuCanvas.SetActive(false);

    }

    public void ToggleGamePause()
    {
        if(isGamePaused == false)
        {
            isGamePaused = true;
            Time.timeScale = 0;

            pauseMenuCanvas.SetActive(true);
        }

        else
        {
            isGamePaused = false;
            Time.timeScale = 1;

            pauseMenuCanvas.SetActive(false);
        }
    }
}
