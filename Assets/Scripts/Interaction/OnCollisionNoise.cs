using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class OnCollisionNoise : MonoBehaviour {

    public float impactSoundThreshold = 0.5f;
    public float maxImpact = 10;
    public float volumeMin = 0;
    public float volumeMax = 1;
    public bool destroy = false;
    public GameObject onDestroyPrefab;

    private AudioSource audioSource;   // Sound played when moving a door
    private Rigidbody rigidBody;
    private float volume;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody>();
	}
	
    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > impactSoundThreshold && !audioSource.isPlaying)
        {
            float min = impactSoundThreshold;
            float value = collision.relativeVelocity.magnitude;
            float volume = Mathf.Lerp(volumeMin, volumeMax, (value - min) / (maxImpact - min));
            audioSource.volume = volume;
            audioSource.Play();

            if (volume == 1 && destroy)
            {
                var instance = Instantiate(onDestroyPrefab, gameObject.GetComponent<Collider>().bounds.center, transform.rotation);
                //var main = instance.GetComponent<ParticleSystem>().main;
                //main.duration = audioSource.clip.length;
                Destroy(gameObject);
            }
        }
    }
}
