using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    [SerializeField] float startPos;
    [SerializeField] float endPos;
    [SerializeField] float moveSpeed = 3f;

    private void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime, 0); ;

        if (transform.position.x <= endPos)
        {
            transform.position = new Vector2(startPos, 0);
        }
    }
}
