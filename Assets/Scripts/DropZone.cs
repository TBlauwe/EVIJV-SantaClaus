using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DropZone : MonoBehaviour {

    public AudioClip onEnter;
    public AudioClip onLeave;
    private AudioSource audioSource;   // Sound played when moving a door
    public List<GameObject> gifts;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerEnter(Collider other)
    {
        Gift gift = other.gameObject.GetComponent<Gift>();

        if(gift)
        {
            gifts.Add(other.gameObject);
            audioSource.clip = onEnter;
            audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Gift gift = other.gameObject.GetComponent<Gift>();

        if(gift)
        {
            gifts.Remove(other.gameObject);
            audioSource.clip = onLeave;
            audioSource.Play();
        }
    }
}
