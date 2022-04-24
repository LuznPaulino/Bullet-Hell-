using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting2 : MonoBehaviour
{
    private float angle = 0f;
    public float fireRate;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, fireRate); //Repeats fire function at a rate of 0.2
    }

    private void Fire() 
    {
        float bulletDirx = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f); //Bullet direction on the x Axis
        float bulletDiry = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f); //Bullet direction on the Y Axis
        
        Vector3 bulletMoveVector = new Vector3(bulletDirx, bulletDiry, 0f); //Vector the bullet will follow
        Vector2 bulletDir = (bulletMoveVector - transform.position).normalized; //Normalize the transition

        GameObject bul = EnemyObjectPool.instance.EnemyPooledObject(); //EnemyObjectPool script called and initalize
        bul.transform.position = transform.position; //Bullet position transformed
        bul.transform.rotation = transform.rotation; //Bullet rotation transformed
        bul.SetActive(true); //Set bullet to Active
        bul.GetComponent<EnemyBullet>().SetDirection(bulletDir); //Set the Direction of the bullet

        angle += 10f; //Sets angle up by 10 every time called
    }

}
