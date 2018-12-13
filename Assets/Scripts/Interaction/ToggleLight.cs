using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ToggleLight : MonoBehaviour {

    public Camera m_camera;
    public AudioClip[] onToggle;

    private AudioSource audioSource;   // Sound played when moving a door
    private int counter = 0;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update()
    {
        // Make sure the user pressed the mouse down
        if (!Input.GetKeyDown(KeyCode.E))
        {
            return;
        }

        var mainCamera = FindCamera();

        // We need to actually hit an object
        RaycastHit hit = new RaycastHit();
        if (
            !Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition).origin,
                             mainCamera.ScreenPointToRay(Input.mousePosition).direction, out hit, 100,
                             Physics.DefaultRaycastLayers))
        {
            return;
        }
        // We need to hit a rigidbody that is not kinematic
        Light pointLight = hit.transform.gameObject.GetComponentInChildren<Light>();
        if(pointLight)
        {
            pointLight.enabled = !pointLight.enabled;
            AudioClip oldClip = audioSource.clip;
            audioSource.clip = onToggle[nextIndex()];
            audioSource.Play();
            audioSource.clip = oldClip;
            return;
        }
    }

    private int nextIndex()
    {
        counter++; 
        if(counter >= onToggle.Length) { counter = 0; }
        return counter;
    }

    private Camera FindCamera()
    {
        if (m_camera) { return m_camera; }

        if (GetComponent<Camera>()){ return GetComponent<Camera>(); }

        return Camera.main;
    }
}
