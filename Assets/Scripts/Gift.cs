using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour {

    [HideInInspector]public float value = 100f;
    public float multiplier = 5f;

	// Use this for initialization
	void Start () {
        value = GetComponent<Rigidbody>().mass * multiplier;		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
