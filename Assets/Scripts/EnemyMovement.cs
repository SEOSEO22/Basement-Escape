using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float damage = 100;
    [SerializeField] int enemyScore = 150;

    Rigidbody2D rigid;
    Animator anim;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Jump();
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        float dir = target.position.x - transform.position.x;

        if (Mathf.Abs(dir) < 8)
        {
            Vector2 nextPos = new Vector2(Mathf.Sign(dir) * Mathf.Abs(moveSpeed), 0f);
            rigid.velocity = nextPos;

            transform.localScale = new Vector3(Mathf.Sign(dir), 1, 1);
        }
        else
        {
            rigid.velocity = new Vector2(moveSpeed, 0f);
            transform.localScale = new Vector3(Mathf.Sign(moveSpeed), 1, 1);
        }
    }

    void Jump()
    {
        anim.SetBool("IsJumping", true);
        Invoke("EndJump", 0.5f);
    }

    void EndJump()
    {
        anim.SetBool("IsJumping", false);
        float ranNum = Random.Range(2f, 6f);
        Invoke("Jump", ranNum);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        moveSpeed = -moveSpeed;
        transform.localScale = new Vector3(Mathf.Sign(moveSpeed), 1, 1);
    }

    // 플레이어를 공격했을 경우
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            FindObjectOfType<GameManager>().Damaged(damage / 1000);
        }
    }

    // 죽었을 경우
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(gameObject);
            FindObjectOfType<GameManager>().GetScore(enemyScore);
        }
    }
}
