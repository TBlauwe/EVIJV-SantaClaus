﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interior : MonoBehaviour {

    //| ========== Related to rain ==========
    public DigitalRuby.RainMaker.RainScript RainScript;

    //| ========== Related to Player sound ==========
    public GameObject Player;

    public AudioClip[] footstepsSnow;
    public AudioClip[] footstepsInterior;

    private UnityStandardAssets.Characters.FirstPerson.FirstPersonController FirstPersonScript;


	// Use this for initialization
	void Start () {

        //| ===== RAIN =====

        //| ===== PLAYER SOUNDS =====
        FirstPersonScript = Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //| ===== RAIN =====
            RainScript.FollowCamera = false;

            //| ===== PLAYER SOUNDS =====
            FirstPersonScript.m_FootstepSounds =  new AudioClip[] { footstepsInterior[0], footstepsInterior[1] };
            FirstPersonScript.m_JumpSound = footstepsInterior[2];
            FirstPersonScript.m_LandSound = footstepsInterior[3];
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //| ===== RAIN =====
            RainScript.FollowCamera = true;

            //| ===== PLAYER SOUNDS =====
            FirstPersonScript.m_FootstepSounds =  new AudioClip[] { footstepsSnow[0], footstepsSnow[1] };
            FirstPersonScript.m_JumpSound = footstepsSnow[2];
            FirstPersonScript.m_LandSound = footstepsSnow[3];
        }
    }
}
