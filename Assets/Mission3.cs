using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Mission3 : MonoBehaviour
{
    public TextMeshProUGUI finalmission;
    private bool goYes = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hero") && goYes == true)
        {

            finalmission.SetText("Now, start the particle cannon to destroy the enemy satellite that is trying to lunch the BioWeapon!");
            goYes = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Hero"))
        {

            finalmission.SetText("");

        }
    }

}
