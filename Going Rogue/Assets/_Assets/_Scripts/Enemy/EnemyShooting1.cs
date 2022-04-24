using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting1 : MonoBehaviour
{
    [SerializeField] private int Enemybullets = 10; //Number of bullets spawned
    [SerializeField] private float startAngle = 0f;  //Starting angle of spread
    [SerializeField] private float endAngle=180f; //Ending angle of spread
    public float bulletForce = 20f; //Force on rigib body 2d
    public Transform firePoint; //Fire point where bullets are launched
    public float fireRate;

    private Vector2 bulletMoveDirection;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Firing", 0f, fireRate);
    }

    private void Firing() 
    {
        float angleStep = (endAngle - startAngle) / Enemybullets; //Sets up angle
        float angle = startAngle; //Sets up starting angle

        for (int i = 0; i < Enemybullets + 1; i++)  //For loop to spawn multiple bullets 
        { 
            float bulletDirx= transform.position.x +Mathf.Sin((angle* Mathf.PI)/180f); //Direction of Xaxis  bullet
            float bulletDiry = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f); //Directionf of Yaxis bullet
            Vector3 bulletMoveVector = new Vector3(bulletDirx,bulletDiry,0f); //The Vector traveled by the bullet 
            Vector2 bulletDir=(bulletMoveVector - transform.position).normalized; //Normalized to have a smooth transition

            GameObject bul = EnemyObjectPool.instance.EnemyPooledObject(); //Calls EnemyObjectPool script 
            bul.transform.position = transform.position; //Transform bullet position
            bul.transform.rotation = transform.rotation; //Transform bullet rotaion
            bul.SetActive(true); //Sets bullet to active
            bul.GetComponent<EnemyBullet>().SetDirection(bulletDir); //Sets Bullet Direction

            angle += angleStep; //Angle increases after every loop
        }
    }

 
}
