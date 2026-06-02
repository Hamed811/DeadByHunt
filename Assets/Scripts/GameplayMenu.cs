using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayMenu : MonoBehaviour
{
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}