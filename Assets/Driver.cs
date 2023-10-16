using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.Analytics;

public class Driver : MonoBehaviour
{

    
    public int score = 0;
    [SerializeField]float rotationSpeed = 0f;
    
    public float speed = 0f;
    [SerializeField]float pressedKeyVertical = 0f;

    [SerializeField] float steerlingSpeed = 200f;
    public float boostTime =0f;

    public float maxSpeed = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
       
        // Rotation Code
        float pressedKeyHorizantal = -Input.GetAxis("Horizontal");
        if (pressedKeyHorizantal > 0 )
        {
            rotationSpeed = (rotationSpeed + steerlingSpeed) * Time.deltaTime;
        }
        else if(pressedKeyHorizantal < 0)
        {
            rotationSpeed = (rotationSpeed - steerlingSpeed )* Time.deltaTime;
        }
        else{
            rotationSpeed = 0;
        }
    

        pressedKeyVertical = Input.GetAxis("Vertical");

        if (pressedKeyVertical > 0 )
        {
           if (speed < 0){
                speed += 0.05f * Time.deltaTime;
            }
            else{
                speed += 0.005f * Time.deltaTime;
            }
        }
        else if (pressedKeyVertical < 0)
        {   
            if (speed > 0){
                speed -= 0.05f * Time.deltaTime;
            }
            else{
                speed -= 0.005f * Time.deltaTime;
            }
         
        }
        else 
        {
            if  (speed != 0){

                // abolute value of speed
                float movespeed = Mathf.Abs(speed);

                // slow down
                movespeed -= 0.05f * Time.deltaTime;

                // clamp
                movespeed = Mathf.Clamp(movespeed, 0, 1);

                // assign back to speed
                speed = movespeed * Mathf.Sign(speed);
            } 
        }
        if (Math.Abs(speed) > maxSpeed){
            if(boostTime > 0){
                speed = maxSpeed * Mathf.Sign(speed) *2;
                boostTime -= Time.deltaTime;
            }
            else{
                speed = Mathf.Sign(speed) * maxSpeed ;
            }
                
            }
        
        if(speed == 0 || speed<0.0025f){
            rotationSpeed=0;
        }
      
       transform.Rotate(0, 0,(float) rotationSpeed);
       transform.Translate(0, speed, 0);
    }
}


