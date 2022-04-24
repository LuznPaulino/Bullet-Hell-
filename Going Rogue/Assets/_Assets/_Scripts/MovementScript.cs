using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f; 
    public Rigidbody2D rb;
    public BoxCollider2D Collider;


    Vector2 movement;

    
    // Update is called once per frame
    void Update()
    {
        movement.x=Input.GetAxisRaw("Horizontal");//Raw input (A or D)

        movement.y=Input.GetAxisRaw("Vertical"); //Input (W or S)
        playerMovement();
    }

    void FixedUpdate() 
    {
        rb.MovePosition(rb.position + movement *moveSpeed* Time.fixedDeltaTime); //Movement speed and position
        

    }
    void playerMovement() 
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -9, 9), Mathf.Clamp(transform.position.y, -5,5)); //Clamps player to prevent them from going off the board
    }
    //Entire Sequence in testing phase
    private void OnCollisionEnter2D(Collision2D otherObj) 
    {
        if (otherObj.transform.tag.Equals("EnemyBullet")) 
        {
            Collider.enabled = false;
            StartCoroutine(EnableCol(2.0f)); //Starts timer and disables collider
        }
        if (otherObj.transform.tag.Equals("Health")) 
        { 
            if (GameControl.control.health < 3) 
            {
                GameControl.control.health += 1;
            }
        }
    }
    IEnumerator EnableCol(float wait) 
    {
        yield return new WaitForSeconds(wait); //Wait for "wait" seconds till collider is enabled 
        Collider.enabled = true;
    }
  
  
}
