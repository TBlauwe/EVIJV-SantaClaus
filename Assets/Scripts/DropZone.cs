using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZone : MonoBehaviour {

    public int counter;

	// Use this for initialization
	void Start () {
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
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Gift gift = other.gameObject.GetComponent<Gift>();

        if(gift)
        {
            counter--;
        }
    }
}
