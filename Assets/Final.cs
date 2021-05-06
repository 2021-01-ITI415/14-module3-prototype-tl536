using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Hero"))
        {

            GameObject.Find("MainMusic").GetComponent<AudioSource>().Stop();
            GameObject.Find("RandomSFX").SetActive(false);
            GameObject.Find("FinalEnd").GetComponent<AudioSource>().Play();

        }
    }
}
