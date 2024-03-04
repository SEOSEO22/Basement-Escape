using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEnding : MonoBehaviour
{
    int life, score, finalScore;
    char rank;

    [SerializeField] TextMeshProUGUI lifeText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI rankText;
    [SerializeField] Button restartButton;

    private void Start()
    {
        life = FindObjectOfType<GameManager>().GetLifeInt();
        score = FindObjectOfType<GameManager>().GetScoreInt();
        finalScore = life * 200 + score;
        lifeText.text = "남은 목숨 : " + life.ToString("D2");
        scoreText.text = "최종 점수 : " + score.ToString("D6");

        if (finalScore >= 6000) rank = 'S';
        else if (finalScore >= 5000) rank = 'A';
        else if (finalScore >= 4500) rank = 'B';
        else if (finalScore >= 4000) rank = 'C';
        else if (finalScore >= 3500) rank = 'D';
        else rank = 'F';

        rankText.text = "RANK : " + rank;

        Invoke("ActiveLifeText", 1f);
    }

    private void ActiveLifeText()
    {
        lifeText.gameObject.SetActive(true);
        Invoke("ActiveScoreText", 1f);
    }

    private void ActiveScoreText()
    {
        scoreText.gameObject.SetActive(true);
        Invoke("ActiveRankText", 1f);
    }

    private void ActiveRankText()
    {
        rankText.gameObject.SetActive(true);
        Invoke("ActiveRestartButton", 1f);
    }

    private void ActiveRestartButton()
    {
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
