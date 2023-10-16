using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCar : MonoBehaviour
{
    [SerializeField] GameObject followCar;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = followCar.transform.position + new Vector3(0,0,-10);
        
    }
}
