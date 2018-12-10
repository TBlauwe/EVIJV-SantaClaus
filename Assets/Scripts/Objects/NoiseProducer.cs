using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseProducer : MonoBehaviour {

    public GameObject noiseLevel;

    public float minNoiseLevel;
    public float maxNoiseLevel;

    private float currentNoiseLevel;

	// Use this for initialization
	void Start () {
        NoiseLevel comp = noiseLevel.GetComponent<NoiseLevel>();
        comp.register(this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setNoiseLevel(float value)
    {
        currentNoiseLevel = Mathf.Clamp(value, minNoiseLevel, maxNoiseLevel);
    }

    public float getNoiseLevel()
    {
        return currentNoiseLevel;
    }
}
