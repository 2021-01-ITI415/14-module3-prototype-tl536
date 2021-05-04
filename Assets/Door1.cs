using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1 : MonoBehaviour
{
    public AudioSource doorSound;
    Animator _doorAnim;
    void Start()
    {
        doorSound = GetComponent<AudioSource>();
        _doorAnim = this.transform.parent.GetComponent<Animator>();
    }
    
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hero")
        {
            doorSound.Play();
            _doorAnim.SetBool("IsOpening", true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Hero")
        {
            doorSound.Play();
            _doorAnim.SetBool("IsOpening", false);
        }
    }
}
