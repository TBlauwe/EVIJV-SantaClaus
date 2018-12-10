using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    private AudioSource audioSource;   // Sound played when moving a door
    private Rigidbody rigidBody;   
    private NoiseProducer noiseProducer;   

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody>();
        noiseProducer = GetComponent<NoiseProducer>();
	}
	
	// Update is called once per frame
	void Update () {
        float magnitude = Mathf.Abs(rigidBody.angularVelocity.y);
        if (magnitude > 0.5f && !audioSource.isPlaying)
        {
            audioSource.Play();
            noiseProducer.setNoiseLevel(magnitude);
        }
        noiseProducer.setNoiseLevel(0.0f);
	}

    void OnCollisionEnter(Collision collision)
    {
        //audioSource.volume = Mathf.Clamp(collision.relativeVelocity.magnitude, 0, 1);
    }
}
