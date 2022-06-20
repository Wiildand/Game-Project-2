using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.InputAction;

public class GameplayManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GlobalProvider globalProvider;
    public GameObject MenuUI;
    public GameObject ControlsUI;

    private void Start() {
        globalProvider.retry.started += ctx   => {
            this.Restart();
        };

        globalProvider.menu.started += ctx  => {
            this.ToggleMenu();
        };

        globalProvider.controls.started += this.ShowControls;
        globalProvider.controls.canceled += this.HideControls;

    }

    public void OnDestroy() {
        globalProvider.retry.started -= ctx   => {
            this.Restart();
        };

        globalProvider.menu.started -= ctx  => {
            this.ToggleMenu();
        };
        globalProvider.controls.started -= this.ShowControls;
        globalProvider.controls.canceled -= this.HideControls;

        Time.timeScale = 1;
    }

    public void ToggleMenu() {
        bool isMenuActive = MenuUI.activeSelf;

        if (!isMenuActive) {
            Time.timeScale = 0;
        } else {
            Time.timeScale = 1;
        }
        MenuUI.SetActive(!isMenuActive);
    }

    public void GoToHome() {
        SceneManager.LoadScene("main");
    }

    private void ShowControls(CallbackContext ctx) {
        ControlsUI.SetActive(true);
    }
    private void HideControls(CallbackContext ctx) {
        ControlsUI.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

}
