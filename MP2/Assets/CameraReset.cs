using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraReset : MonoBehaviour {
    //Camera MainCamera;
    public GameObject player;
    // Use this for initialization
    void Start () {
      //  MainCamera = Camera.main;
      //  MainCamera.enabled = true;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            player.transform.position = new Vector3(0, 1, -10);
            player.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //if(Input.GetKeyDown("l")){
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
			    Application.Quit();
            #endif
        }
    }
}
