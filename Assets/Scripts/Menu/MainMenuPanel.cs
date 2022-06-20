using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuPanel : MonoBehaviour {
    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitMenu() {
        Application.Quit();
    }
}
