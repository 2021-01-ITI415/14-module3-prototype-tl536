using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interaction2 : MonoBehaviour
{
    private bool inrange = false;
    public TextMeshProUGUI interact;
    public TextMeshProUGUI generation;
    public int generated;
    private bool genYes = false;
    public AudioSource startaudio;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inrange == true && genYes == false)
        {
            GameObject.Find("Particle System2").GetComponent<ParticleSystem>().Play();
            GameObject.Find("Particle System2").GetComponent<ParticleSystem>().enableEmission = true;
            interact.SetText("");
            generated++;

            generation.SetText(generated.ToString());
            genYes = true;
            startaudio.Play();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hero"))
        {
            generated = int.Parse(generation.text);
            inrange = true;
            interact.SetText("Press E to start");

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Hero"))
        {
            inrange = false;
            interact.SetText("");

        }
    }
}
