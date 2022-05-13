using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuPanel : MonoBehaviour {
    public void PlayGame() {
        SceneManager.LoadScene("character");
    }

    public void QuitMenu() {
        Application.Quit();
    }
}
