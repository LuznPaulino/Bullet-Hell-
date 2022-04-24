using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance; //Sets instance 
    private List<GameObject> pooledObjects = new List<GameObject>(); //Set list 
    private int amountPool = 20; //Set max bullet to 20

    [SerializeField] private GameObject bullet;

    private void Awake() //Check if instance is not null 
    {
        if (instance == null) 
        {
            instance = this;
        }
    
    }
    void Start() //Set List and add bullets to the list 
    {
        for (int i=0; i < amountPool; i++) 
        {
            GameObject obj = Instantiate(bullet);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject PooledObjects() //Checks list and return bullet or null
    {
        for (int i = 0; i < pooledObjects.Count; i++) 
        {
            if (!pooledObjects[i].activeInHierarchy) 
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
