using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SpatialTracking;

public class ToggleTracking : MonoBehaviour {

    int p = 1;
    int r = 1;
    public GameObject mainCamera;
    public GameObject mainCamera2;
    public TrackedPoseDriver t;
    Quaternion cPR;
    Quaternion cR;
    // Use this for initialization
    void Start () {
        t = GetComponent<TrackedPoseDriver>();
	}

    // Update is called once per frame
    void LateUpdate () {

        if (Input.GetKeyDown(KeyCode.R))
        {
            r *= -1;
            cPR = mainCamera.transform.rotation;
            cR = mainCamera2.transform.rotation;
            
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            print("here");

            p *= -1;
            if (p == -1)
            {
                UnityEngine.XR.InputTracking.disablePositionalTracking = true;
            }
            if (p == 1)
            {
                UnityEngine.XR.InputTracking.disablePositionalTracking = false;
            }

        }
        if (r == -1)
        {
            print("rotation");

            Quaternion delta = Quaternion.Inverse(cR)*mainCamera2.transform.rotation;
            mainCamera.transform.rotation = cPR*Quaternion.Inverse(delta);
           // mainCamera.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }

    }
}
