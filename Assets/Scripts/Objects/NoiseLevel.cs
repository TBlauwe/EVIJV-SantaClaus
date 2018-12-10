using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseLevel : MonoBehaviour {

    public float maxNoiseLevel;

    private List<NoiseProducer> noiseProducers = new List<NoiseProducer>();

	// Use this for initialization
	void Start()
    {

    }

    void Update()
    {
        Debug.Log("Noise level : " + getNoiseLevel().ToString());
    }

    public float getNoiseLevel()
    {
        float noiseLevel = 0.0f;
        foreach(NoiseProducer noiseProducer in noiseProducers)
        {
            noiseLevel += noiseProducer.getNoiseLevel();
        }
        return noiseLevel;
	}

    public void register(NoiseProducer noiseProducer)
    {
        noiseProducers.Add(noiseProducer);
    }
}
