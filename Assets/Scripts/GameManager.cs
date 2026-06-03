using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject winTextObject;
    public TMP_Text winText;

    private void Awake()
    {
        Instance = this;
    }

    public void EndGame(string winner)
    {
        winTextObject.SetActive(true);

        winText.text = winner;

        Time.timeScale = 0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}