using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    
    public Transform customPivot;
    


    public void Update()
    {
        transform.RotateAround(customPivot.position, Vector3.up, 25 * Time.deltaTime);
    }

}

