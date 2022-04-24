using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBullet : MonoBehaviour
{
    private Vector2 Direction;
    private float moveSpeed;
    public GameObject bullet;

    private void OnEnable() 
    {
        Invoke("Destroy", 4f);
    }
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Direction * moveSpeed * Time.deltaTime);
        if (GameControl.control.health <= 0) 
        {
            SceneManager.LoadScene(1);
        }
    }

    public void SetDirection(Vector2 dir) 
    {
        Direction = dir;
    }
    private void Destroy() 
    {
        gameObject.SetActive(false);
    }
    private void OnDisable() 
    { 
        CancelInvoke();
    }
    private void OnCollisionEnter2D(Collision2D OtherObj)
    {
        if (OtherObj.transform.tag.Equals("Player"))
        {
            GameControl.control.health -= 1;

        }
        gameObject.SetActive(gameObject);
    }
}
