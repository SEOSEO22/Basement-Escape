using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float damage = 200f;
    Rigidbody2D rigid;
    Vector2 launchDir;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        launchDir = (transform.position - target.position).normalized;
        Destroy(gameObject, 5f);
    }

    private void Update()
    {
        rigid.velocity = launchDir * 10f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);

        if (collision.gameObject.name == "Player")
        {
            FindObjectOfType<GameManager>().Damaged(damage / 1000);
        }
    }
}
