using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class Trigger : MonoBehaviour
{
    public AudioSource cannon;
    public AudioClip startcannon;
    public AudioClip shootcannon;
    public AudioClip victory;

    public TextMeshProUGUI trigger;
    public GameObject Laser;
    private bool inrange = false;
    private bool fired = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inrange == true && fired == false)
        {

            StartCoroutine(ExampleCoroutine());


        }

    }
    private void OnTriggerEnter(Collider other)
    {
        inrange = true;
        if (other.gameObject.CompareTag("Hero") && fired == false)
        {

            trigger.SetText("Press E to start the particle cannon");

        }
    }
    IEnumerator ExampleCoroutine()
    {
        fired = true;
        trigger.SetText("");
        cannon.PlayOneShot(startcannon);
        yield return new WaitForSeconds(1);
        GameObject.Find("Particle System0").GetComponent<ParticleSystem>().Play();
        GameObject.Find("Particle System0").GetComponent<ParticleSystem>().enableEmission = true;
        yield return new WaitForSeconds(2);
        cannon.PlayOneShot(shootcannon);
        Laser.SetActive(true);

        yield return new WaitForSeconds(1);
        trigger.SetText("Particle cannon activated");
        yield return new WaitForSeconds(2);
        trigger.SetText("Mission Accomplished!");
        cannon.PlayOneShot(victory);



    }
}
