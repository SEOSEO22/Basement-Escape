using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] int enemyScore = 200;
    [SerializeField] float bulletSpeed = 20f;
    Image enemyHPBar;
    Rigidbody2D bulletRigid;
    PlayerMovement playerMovement;
    float xSpeed;

    private void Start()
    {
        Destroy(gameObject, 3f);
        bulletRigid = GetComponent<Rigidbody2D>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        xSpeed = playerMovement.transform.localScale.x * bulletSpeed;

        if (GameObject.Find("Enemy"))
        {
            enemyHPBar = FindObjectOfType<MachineMovement>().hpBarTransform.gameObject.GetComponent<Image>();
        }
    }

    private void Update()
    {
        bulletRigid.velocity = new Vector2(xSpeed, 0f);
        transform.Rotate(new Vector3(0, 0, 1f));
        transform.Rotate(new Vector3(0, 0, 20f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);

        if (collision.gameObject.name == "Enemy")
        {
            enemyHPBar.fillAmount -= 0.1f;
            FindObjectOfType<MachineMovement>().Damaged(enemyScore);
        }
    }
}
