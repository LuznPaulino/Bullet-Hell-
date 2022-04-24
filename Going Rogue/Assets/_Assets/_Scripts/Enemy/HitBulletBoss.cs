using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBulletBoss : MonoBehaviour
{
    public int health = 100; //Health of Enemy
    public void Hit()
    {
        health -= 1; //Reduce health by one (Can be changed for gameplay purposes)
        GameControl.control.points += 2; //Points per hit
        if (health <= 1)
        {
            GameControl.control.points += 50; //Points on death
            Destroy(gameObject);
            
        }

    }
}
