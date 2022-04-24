using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScirpt : MonoBehaviour
{
    public GameObject bullet;
    private void OnCollisionEnter2D(Collision2D OtherObj) 
    {
        if (OtherObj.transform.tag.Equals("Destroy")) 
        {
            OtherObj.transform.SendMessage("Hit", SendMessageOptions.DontRequireReceiver); //Hit message Sent

        }
        gameObject.SetActive(false); //Bullet set false 
    }
}
