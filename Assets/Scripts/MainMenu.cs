using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        if (MapManager.selectedMap == 1)
            SceneManager.LoadScene("Gameplay");
        else if (MapManager.selectedMap == 2)
            SceneManager.LoadScene("Gameplay 1");
        else if (MapManager.selectedMap == 3)
            SceneManager.LoadScene("Gameplay 2");
    }

    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}