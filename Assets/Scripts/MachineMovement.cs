using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float launchSpeed = 2f;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    
    Rigidbody2D rigid;
    float moveDir = 1f;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
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
    }

    private void Launch()
    {
        Instantiate(bullet, gun.position, transform.rotation);
        Invoke("Launch", launchSpeed);
    }
}
