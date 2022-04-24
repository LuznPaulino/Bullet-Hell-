using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCrazyMovemet : MonoBehaviour
{
    private bool Up;
    private bool Right;
    public float moveSpeed;
    void Start()
    {
        Up = true;
        Right = true;
    }

    void Update()
    {
        if (transform.position.x > 7f)
        {
            Right = false;
        }
        else if (transform.position.x < -7f)
        {
            Right = true;
        }

        if (Right)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }

        if (transform.position.y > 4f)
        {
            Up = false;
        }
        else if (transform.position.y < -4f)
        {
            Up = true;
        }
        if (Up)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
        }

    }
}
