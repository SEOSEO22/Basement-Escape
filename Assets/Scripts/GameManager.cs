using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject exitCanvas;
    [SerializeField] Image healthGauge;
    [SerializeField] TextMeshProUGUI lifeText;
    [SerializeField] TextMeshProUGUI scoreText;

    int life = 3;
    int score = 0;
    bool isClickedESCOnce = false;

    // GameManager가 하나만 존재할 수 있도록 싱글톤 패턴 사용
    private void Awake()
    {
        int gameManagerLength = FindObjectsOfType<GameManager>().Length;

        if (gameManagerLength > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        lifeText.text = life.ToString("D2");
        scoreText.text = score.ToString("D6");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isClickedESCOnce)
            {
                exitCanvas.SetActive(true);
                isClickedESCOnce = true;
                Time.timeScale = 0;
            }
            else
            {
                exitCanvas.SetActive(false);
                isClickedESCOnce = false;
                Time.timeScale = 1f;
            }
        }
    }

    public void Damaged(float damage)
    {
        if ((healthGauge.fillAmount - damage) > 0f)
        {
            healthGauge.fillAmount -= damage;
        }
        else
        {
            Die();
        }
    }

    public void GetScore(int scoreNum)
    {
        this.score += scoreNum;
        scoreText.text = score.ToString("D6");
    }

    private void Die()
    {
        if (life > 1)
        {
            life--;
            lifeText.text = life.ToString("D2");
            healthGauge.fillAmount = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            Destroy(gameObject);
            SceneManager.LoadScene(0);
        }
    }

    public void ExitGameOnPlaying()
    {
        Time.timeScale = 1f;
        Destroy(gameObject);
        SceneManager.LoadScene(0);
    }

    public int GetLifeInt()
    {
        return life;
    }

    public int GetScoreInt()
    {
        return score;
    }
}
