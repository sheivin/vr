using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightswitch : MonoBehaviour {

	public Light light;

	void Start() {
		light = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		//Light.color newColor = new Color(red, green, blue);
		if (Input.GetKeyDown("tab"))
		{
			//light.color = Light.color.red;
		}
	}
}