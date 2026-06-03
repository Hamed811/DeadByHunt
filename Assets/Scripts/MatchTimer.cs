using UnityEngine;
using TMPro;

public class MatchTimer : MonoBehaviour
{
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

        UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(matchTime / 60);
        int seconds = Mathf.FloorToInt(matchTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}