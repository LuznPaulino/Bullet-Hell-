using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovemet : MonoBehaviour
{
    public float moveSpeed;
    public bool Up;
    // Start is called before the first frame update
    void Start()
    {
        Up = true;
    }

    // Update is called once per frame
    void Update()
    {
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
