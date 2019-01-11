using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour {

    public float height = 0.9f;
    public KeyCode key;
    public float cameraHeightRelativeY = 0.5f;

    private CharacterController controller;
    private CapsuleCollider pushCollider;
    private float initialHeight;
    private float initialHeightPush;
    private bool isCrouching = false;
    private bool cached_isCrouching = false;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
        pushCollider = GetComponentInChildren<CapsuleCollider>();

        initialHeight = controller.height;
        initialHeightPush = pushCollider.height;

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
                controller.height = height;
                pushCollider.height = height - 0.2f;
            }
            else
            {
                controller.height = initialHeight;
                pushCollider.height = initialHeightPush;
            }
        }
	}
}
