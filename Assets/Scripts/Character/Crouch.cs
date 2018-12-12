using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour {

    public float height = 0.9f;
    public KeyCode key;
    private CharacterController controller;
    private BoxCollider pushCollider;
    private float initialHeight;
    private float initialHeightPush;
    private bool isCrouching = false;
    private bool cached_isCrouching = false;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
        pushCollider = GetComponentInChildren<BoxCollider>();

        initialHeight = controller.height;
        initialHeightPush = pushCollider.size.y;

        cached_isCrouching = isCrouching;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(key)) {
            isCrouching = !isCrouching;
        }

        if(isCrouching != cached_isCrouching)
        {
            cached_isCrouching = isCrouching;
            if (isCrouching)
            {
                Debug.Log("Crouching ...");
                    
                controller.height = height;
                pushCollider.size = new Vector3(pushCollider.size.x, height - 0.2f, pushCollider.size.z);
            }
            else
            {
                Debug.Log("Not Crouching ...");

                controller.height = initialHeight;
                pushCollider.size = new Vector3(pushCollider.size.x, initialHeightPush, pushCollider.size.z);
            }
        }
	}
}
