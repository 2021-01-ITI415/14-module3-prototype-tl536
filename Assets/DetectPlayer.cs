using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Hero"))
        {

            this.transform.GetChild(0).gameObject.SetActive(true);

        }
    }
}
