using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DropZone : MonoBehaviour {

    public int counter;
    public AudioClip onEnter;
    public AudioClip onLeave;
    private AudioSource audioSource;   // Sound played when moving a door

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        counter = 0;		
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerEnter(Collider other)
    {
        Gift gift = other.gameObject.GetComponent<Gift>();

        if(gift)
        {
            counter++;
            audioSource.clip = onEnter;
            audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Gift gift = other.gameObject.GetComponent<Gift>();

        if(gift)
        {
            counter--;
            audioSource.clip = onLeave;
            audioSource.Play();
        }
    }
}
