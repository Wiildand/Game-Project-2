using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.InputAction;

public class GameplayManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GlobalProvider globalProvider;



    private void Start() {
        globalProvider.retry.started += ctx   => {
            this.Restart();
        };
        
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
