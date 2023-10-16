using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
     public bool isColeccted = false;
    GameObject[] taggedObjects;
    String targetTag = "Road";

    void Start()
    {
    taggedObjects = GameObject.FindGameObjectsWithTag(targetTag); 
    }
   void Update()
   {

    if (isColeccted){
        int randomIndex = Random.Range(0, taggedObjects.Length);
        GameObject cargo = GameObject.FindGameObjectsWithTag("Cargo")[0];
        //Instantiate( cargo, taggedObjects[randomIndex].transform.position, Quaternion.identity);
        cargo.transform.position = taggedObjects[randomIndex].transform.position;
        isColeccted = false;
    }
   }
}
