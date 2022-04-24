using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePoint;
    public GameObject bulletprefab;

    public float bulletForce= 20f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))  //Check for fire button (Left click)
        {
            Shoot();
            
        }
        

    }

    void Shoot() 
    {
        GameObject bullet = ObjectPool.instance.PooledObjects(); //Sets Object pool script to bullet 
        
        //Instantiate(bulletprefab, firePoint.position,firePoint.rotation);
        
        Rigidbody2D rb=bullet.GetComponent<Rigidbody2D>(); //Sets rigid body to bullet 

        if (bullet != null)
        {
            bullet.transform.position = firePoint.position; //Set bullet position to fire point
            bullet.SetActive(true); //Set bullet to Active
            rb.AddForce((firePoint.right * -1) * bulletForce, ForceMode2D.Impulse); //Rigid body is given force to move 
        }
    }
}
