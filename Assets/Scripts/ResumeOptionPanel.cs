using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResumeOptionPanel : MonoBehaviour {
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUi;

    private void Update() {
        /// Todo manage with the new input system
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void GoToMenu() {
        SceneManager.LoadScene("main");
    }
    public void Resume() {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = false;
    }

    private void Pause() {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitMenu() {
        Application.Quit();
    }
}
