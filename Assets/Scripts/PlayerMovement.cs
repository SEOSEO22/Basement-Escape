using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float walkingSpeed = 5f;
    [SerializeField] float jumpSpeed = 10f;

    Vector2 moveInput;
    Rigidbody2D playerRigid;
    BoxCollider2D swordCollider;
    Animator anim;

    private void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        swordCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        Walk();
        FlipSprite();
        Attack();
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void Walk()
    {
        playerRigid.velocity = new Vector2(moveInput.x * walkingSpeed, playerRigid.velocity.y);

        bool isRunning = Mathf.Abs(playerRigid.velocity.x) > Mathf.Epsilon;
        anim.SetBool("IsRunning", isRunning);
    }

    private void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            playerRigid.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    private void FlipSprite()
    {
        bool isRunning = Mathf.Abs(moveInput.x) > Mathf.Epsilon;

        if (isRunning)
        {
            transform.localScale = new Vector3(Mathf.Sign(moveInput.x), 1, 1);
        }
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("IsAttack", true);
            swordCollider.enabled = true;

            Invoke("StopAttack", 0.5f);
        }
    }

    private void StopAttack()
    {
        swordCollider.enabled = false;
        anim.SetBool("IsAttack", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (swordCollider.IsTouchingLayers(LayerMask.GetMask("Enemy")) && collision.tag == "Enemy")
        {
            FindObjectOfType<GameManager>().GetScore(FindObjectOfType<EnemyMovement>().enemyScore);
            Destroy(collision.gameObject);
        }
    }
}
