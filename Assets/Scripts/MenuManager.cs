using UnityEngine;
using TMPro;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    public GameObject settingsPanel;
    public TMP_Text difficultyText;

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }
    public GameObject tutorialPanel;

    public void OpenTutorial()
    {
        tutorialPanel.SetActive(true);
    }

    public void CloseTutorial()
    {
        tutorialPanel.SetActive(false);
    }

    public IEnumerator ShowDifficultyText(string message)
    {
        difficultyText.gameObject.SetActive(true);

        difficultyText.text = message;

        yield return new WaitForSeconds(2f);

        difficultyText.gameObject.SetActive(false);
    }

    public void SetEasy()
    {
        GameSettings.SurvivorHP = 3;
        GameSettings.MatchTime = 80f;

        StartCoroutine(
            ShowDifficultyText("EASY SELECTED!")
        );
    }

    public void SetNormal()
    {
        GameSettings.SurvivorHP = 2;
        GameSettings.MatchTime = 60f;

        StartCoroutine(
            ShowDifficultyText("NORMAL SELECTED!")
        );
    }

    public void SetHard()
    {
        GameSettings.SurvivorHP = 1;
        GameSettings.MatchTime = 40f;

        StartCoroutine(
            ShowDifficultyText("HARD SELECTED!")
        );
    }
}