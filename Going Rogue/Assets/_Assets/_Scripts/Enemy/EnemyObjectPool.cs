using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectPool : MonoBehaviour
{
    public static EnemyObjectPool instance; //Sets instance of the Script
    private List<GameObject> EnemyPooledObjects = new List<GameObject>(); //Sets list for bullets 
    private int amountPool = 20; //The max number of bullets

    [SerializeField] private GameObject bullet; //Serialize bullet 

    private void Awake() //On Awake check if instance is not null and add bullets to the list 
    {
        if (instance == null)
        {
            instance = this;
        }
        for (int i = 0; i < amountPool; i++)
        {
            GameObject obj = Instantiate(bullet);
            obj.SetActive(false);
            EnemyPooledObjects.Add(obj);
        }
        
    }

    public GameObject EnemyPooledObject() //Checks the list and returns bullet when function called
    {
        for (int i = 0; i < EnemyPooledObjects.Count; i++)
        {
            if (!EnemyPooledObjects[i].activeInHierarchy)
            {
                return EnemyPooledObjects[i];
            }
        }
        return null; //If list is empty return null 
    }
}
