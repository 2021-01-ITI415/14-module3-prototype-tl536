using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLight : MonoBehaviour
{

	Light light;
	public AudioSource ToggleSound;
	public AudioClip ToggleS;

	// Use this for initialization
	void Start()
	{
		light = GetComponent<Light>();
	}

	// Update is called once per frame
	void Update()
	{
		// Toggle light on/off when L key is pressed.
		if (Input.GetKeyUp(KeyCode.F))
		{
			ToggleSound.PlayOneShot(ToggleS);
			light.enabled = !light.enabled;
		}
	}
}