using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int coinScore = 500;
    AudioClip audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>().clip;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            AudioSource.PlayClipAtPoint(audio, Camera.main.transform.position);
            Destroy(gameObject);
            FindObjectOfType<GameManager>().GetScore(coinScore);
        }
    }
}
