using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cargo : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    bool hasPackage = false;
    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other) {

        if(other.tag == "Cargo" && !hasPackage){
            Debug.Log("Package is picked up");
            hasPackage = true;
            spriteRenderer.color = new Color32(1,1,122,50);
            GameObject [] cargo = GameObject.FindGameObjectsWithTag("Cargo");
            if(cargo.Length ==1){
                cargo[0].GetComponent<Spawner>().isColeccted = true;
            }
        }

        if(other.tag == "Customer" && hasPackage){
            Debug.Log("Package is arrived");
            hasPackage = false;
            Debug.Log( GetComponent<Driver>().score+=1);
            
        }

        if(other.tag == "SpeedUp"){
            GetComponent<Driver>().speed = 5f;
            GetComponent<Driver>().boostTime = 1f;
            Debug.Log("asdfasfsafasfsa");
        }
        
    }
   
}
