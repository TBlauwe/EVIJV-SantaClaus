using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightLED : MonoBehaviour {

    public List<Color> colors = new List<Color>(); // List of colors to be displayed one at a time
    public float delay = 1.0f; // Time per color

    private Material material;
    private Light light;
    private float lastSwitch;
    private int index;

	// Use this for initialization
	void Start () {
        index       = Random.Range(0, colors.Count);
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
        if (index >= colors.Count)
            index = 0;
        Color color = colors[index];
        material.SetColor("_Color", color);
        light.color = color;
        index++;

        lastSwitch = Time.time;
    }
}
