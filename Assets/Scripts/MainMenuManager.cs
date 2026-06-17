using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        switch (MapManager.selectedMap)
        {
            case 1:
                SceneManager.LoadScene("Gameplay");
                break;

            case 2:
                SceneManager.LoadScene("Gameplay 1");
                break;

            case 3:
                SceneManager.LoadScene("Gameplay 2");
                break;
        }
    }
}