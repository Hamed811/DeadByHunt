using UnityEngine;
using TMPro;

public class MatchTimer : MonoBehaviour
{
    public PlayerMovement killerMovement;

    private bool bloodlust1Activated = false;
    private bool bloodlust2Activated = false;
  
    public float matchTime = 120f;

    public TMP_Text timerText;

    private bool matchEnded = false;

    void Update()
    {

        if (matchEnded)
            return;

        matchTime -= Time.deltaTime;

        if (matchTime <= 0)
        {
            matchTime = 0;
            matchEnded = true;

            GameManager.Instance.EndGame("SURVIVOR WINS");
        }
        if (!bloodlust1Activated && matchTime <= 25f)
        {
            bloodlust1Activated = true;

            killerMovement.moveSpeed += 0.5f;
            killerMovement.currentSpeed += 0.5f;

            StartCoroutine(
                GameManager.Instance.ShowBloodlustText()
            );
        }

        if (!bloodlust2Activated && matchTime <= 5f)
        {
            bloodlust2Activated = true;

            killerMovement.moveSpeed += 1f;
            killerMovement.currentSpeed += 1f;

            StartCoroutine(
                GameManager.Instance.ShowBloodlustText()
            );
        }


        UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(matchTime / 60);
        int seconds = Mathf.FloorToInt(matchTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}