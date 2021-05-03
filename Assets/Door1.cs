using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1 : MonoBehaviour
{
    Animator _doorAnim;
    void Start()
    {
        _doorAnim = this.transform.parent.GetComponent<Animator>();
    }
    
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hero")
        {
            _doorAnim.SetBool("IsOpening", true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Hero")
        {
            _doorAnim.SetBool("IsOpening", false);
        }
    }
}
