using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
using TMPro;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{

    public SurvivorHealth survivor;
    public GameObject speedBoostText;
    public GameObject bloodlustText;
    private List<float> destroyedPassages = new List<float>();

    private bool antiPassageCooldown = false;
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
    public void PassageDestroyed()
    {
        destroyedPassages.Add(Time.time);

        destroyedPassages.RemoveAll(
            time => Time.time - time > 20f
        );

        if (destroyedPassages.Count >= 4 && !antiPassageCooldown)
        {
            StartCoroutine(GiveSurvivorBoost());
        }
    }
    IEnumerator GiveSurvivorBoost()
    {
        antiPassageCooldown = true;
        StartCoroutine(ShowSpeedBoostText());

        Debug.Log("Anti Passage Buff Triggered!");

        PlayerMovement movement =
            survivor.GetComponent<PlayerMovement>();

        movement.currentSpeed += 2f;

        yield return new WaitForSeconds(5f);

        movement.currentSpeed = movement.moveSpeed;

        yield return new WaitForSeconds(30f);

        antiPassageCooldown = false;
    }
    IEnumerator ShowSpeedBoostText()
    {
        speedBoostText.SetActive(true);

        yield return new WaitForSeconds(2f);

        speedBoostText.SetActive(false);
    }

    public IEnumerator ShowBloodlustText()
    {
        bloodlustText.SetActive(true);

        yield return new WaitForSeconds(2f);

        bloodlustText.SetActive(false);
    }
}

