using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFlipper : MonoBehaviour {
    //Camera MainCamera;
    public GameObject player;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F))
        {
            player.transform.rotation *= Quaternion.Euler(0, 180, 0);
        }
    }
}
