using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Image healthGauge;
    [SerializeField] TextMeshProUGUI lifeText;
    [SerializeField] TextMeshProUGUI scoreText;

    int life = 3;
    int score = 0;

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

    public void Damaged(float damage)
    {
        if ((healthGauge.fillAmount - damage) > 0)
        {
            healthGauge.fillAmount -= damage;
        }
        else
        {
            Die();
        }
    }

    public void GetScore(int score)
    {
        this.score += score;
        scoreText.text = score.ToString("D6");
    }

    private void Die()
    {
        if (life > 1)
        {
            life--;
            lifeText.text = life.ToString("D2");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            Destroy(gameObject);
            SceneManager.LoadScene(0);
        }
    }
}
