using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Detection : MonoBehaviour
{

    public int hasgenerated;
    public TextMeshProUGUI opennum;
    public TextMeshProUGUI missiontext;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        hasgenerated = int.Parse(opennum.text);
        if (other.gameObject.CompareTag("Hero"))
        {
            if (hasgenerated == 4)
            {
                Destroy(gameObject);
            }
            else
            {
                missiontext.SetText("I need to start tbe 4 generators!");
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Hero"))
        {
            missiontext.SetText("");

        }
    }

}
