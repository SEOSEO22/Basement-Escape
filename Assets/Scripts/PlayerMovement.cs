using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEditor.PlayerSettings;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float walkingSpeed = 5f;
    [SerializeField] float jumpSpeed = 10f;
    [SerializeField] BoxCollider2D bottomCollider;
    [SerializeField] Color32 normalColor;
    [SerializeField] Color32 damagedColor;

    Vector2 moveInput;
    Rigidbody2D playerRigid;
    BoxCollider2D swordCollider;
    Animator anim;
    SpriteRenderer spriteRenderer;
    bool isAttack = false;

    [Header("Audio")]
    AudioSource audio;
    [SerializeField] AudioClip walk;
    [SerializeField] AudioClip attack;

    private void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        swordCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Walk();
        FlipSprite();
        Attack();
        PlayerMoveInCamera();
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

        if (isRunning && !audio.isPlaying && bottomCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            audio.PlayOneShot(walk);
        }
    }

    private void OnJump(InputValue value)
    {
        if (value.isPressed && bottomCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
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
        if (Input.GetMouseButtonDown(0) && !isAttack)
        {
            isAttack = true;
            audio.PlayOneShot(attack);
            anim.SetBool("IsAttack", true);
            swordCollider.enabled = true;

            Invoke("StopAttack", 0.5f);
        }
    }

    private void StopAttack()
    {
        swordCollider.enabled = false;
        anim.SetBool("IsAttack", false);
        isAttack = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 다음 레벨로 가는 도착 지점에 도달했을 경우
        if (collision.gameObject.tag == "NextLevel")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    // 플레이어의 움직임을 카메라 내로 제한
    void PlayerMoveInCamera()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) pos.x = 0f;
        if (pos.y < 0f) pos.y = 0f;
        if (pos.x > 1f) pos.x = 1f;
        if (pos.y > 1f) pos.y = 1f;
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
