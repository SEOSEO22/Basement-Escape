using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Transform target;
    Rigidbody2D rigid;
    Vector2 launchDir;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        launchDir = (transform.position - target.position).normalized;
    }

    private void Update()
    {
        rigid.velocity = launchDir * 10f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
