using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSFX : MonoBehaviour
{
    public AudioSource ramdomclip;
    public AudioClip[] radomArray;



    // Start is called before the first frame update
    void Awake()
    {
        ramdomclip = GetComponent<AudioSource>();
    }
    void Start()
    {


        StartCoroutine("RandomScary");



    }


    IEnumerator RandomScary()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            ramdomclip.clip = radomArray[Random.Range(0, radomArray.Length)];
            ramdomclip.PlayOneShot(ramdomclip.clip);
            

        }


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
