using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightLED : MonoBehaviour {

    public List<Color> colors = new List<Color>(); // List of colors to be displayed one at a time
    public float intensity = 3.0f; // Time per color
    public float delay = 1.0f; // Time per color
    public int startingIndex = 0;

    private Material material;
    private Light light;
    private float lastSwitch;

	// Use this for initialization
	void Start () {
        material    = GetComponent<Renderer>().material;
        light       = GetComponent<Light>();
        switchColor();
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time - lastSwitch > delay)
            switchColor();
	}

    private void switchColor()
    {
        if (startingIndex >= colors.Count)
            startingIndex = 0;
        Color color = colors[startingIndex];
        material.SetColor("_Color", color);
        material.SetColor("_EmissionColor", color*intensity);
        light.color = color;
        startingIndex++;

        lastSwitch = Time.time;
    }
}
