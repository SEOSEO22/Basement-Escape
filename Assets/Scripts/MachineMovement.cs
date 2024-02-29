using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachineMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float launchSpeed = 2f;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;

    Rigidbody2D rigid;
    float moveDir = 1f;

    [Header("UI")]
    [SerializeField] GameObject Canvas;
    [SerializeField] GameObject HPBar;
    RectTransform hpBarTransform;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        hpBarTransform = Instantiate(HPBar, Canvas.transform).GetComponent<RectTransform>();
        HPBar.GetComponent<Image>().fillAmount = 1;
        Launch();
    }

    private void Update()
    {
        rigid.velocity = new Vector2(0, moveDir * moveSpeed);

        if (transform.position.y >= 3)
        {
            moveDir = -1;
        }
        else if (transform.position.y <= -1)
        {
            moveDir = 1;
        }

        HPBarUI();
    }

    private void Launch()
    {
        Instantiate(bullet, gun.position, transform.rotation);
        Invoke("Launch", launchSpeed);
    }

    private void HPBarUI()
    {
        Vector3 enemyHPTransform =
            Camera.main.WorldToScreenPoint(new Vector3(transform.position.x + .5f, transform.position.y - 1.5f, 0));
        hpBarTransform.position = enemyHPTransform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            hpBarTransform.gameObject.GetComponent<Image>().fillAmount -= 0.1f;
        }
    }
}
