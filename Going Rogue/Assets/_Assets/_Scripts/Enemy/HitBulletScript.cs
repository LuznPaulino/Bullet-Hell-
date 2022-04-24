using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Same as Boss Script but for minions
public class HitBulletScript : MonoBehaviour
{
    public int health = 1;
    public void Hit() 
    {
        health -= 1;
        if (health <= 1) 
        {
            GameControl.control.points += 1;
            Destroy(gameObject);
        }
        
    }
}
