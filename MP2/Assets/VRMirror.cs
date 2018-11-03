using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRMirror : MonoBehaviour {
    public GameObject player;
    public GameObject Pcamera;
    public GameObject cube;
    Vector3 previousPlayerPos;
    Vector3 previousCubePos;
    Vector3 prevPlayerRot;

    bool mPressed = false;
    int m = -1;
    int count = 0;
    // Use this for initialization
    void Start () {
        previousPlayerPos = player.transform.position;
        prevPlayerRot = Pcamera.transform.eulerAngles;
        previousCubePos = cube.transform.position;
    }

    Vector3 angleCalc(Vector3 res)
    {
        //Vector3 res = curr - prev;
        res.x = (360+res.x) % 360;
        res.y = (360+res.y) % 360;
        res.z = (360+res.z) % 360;
        return res;
    }
    Vector3 angleCalc2(Vector3 curr, Vector3 prev)
    {
        Vector3 res = curr - prev;
        print(res);
        if(res.x < 0)
        {
            res.x = Mathf.Abs(res.x) % 360;
        }
        else if (res.x > 0)
        {
            res.x = -(res.x % 360) + 360;
        }
        if (res.y < 0)
        {
            res.y = Mathf.Abs(res.y) % 360;

        }
        else if (res.y > 0)
        {
            res.y = -(res.y % 360) + 360;
        }
        if (res.z < 0)
        {
            res.z = Mathf.Abs(res.z) % 360;
        }
        
        else if (res.z > 0)
        {
            res.z = -(res.z % 360) + 360;
        }
        res.x = (res.x) % 360;
        res.y = (res.y) % 360;
        res.z = (res.z) % 360;
        print(res);
        return res;
    }
    void match(GameObject player, GameObject cube)
    {
        Vector3 playerPos = player.transform.position;
        Vector3 cubePos = cube.transform.position;
        Vector3 playerOffSet = playerPos - previousPlayerPos;
        cube.transform.position = cubePos + playerOffSet;

        Vector3 playerRot = Pcamera.transform.eulerAngles;
        Vector3 rOffSet = -prevPlayerRot + playerRot;
        Vector3 cubeRot = cube.transform.eulerAngles;
        cube.transform.eulerAngles = cubeRot + rOffSet;
      

        //print(playerRot);
        //print(prevPlayerRot);
        prevPlayerRot = Pcamera.transform.eulerAngles;
        previousPlayerPos = playerPos;
        previousCubePos = cubePos;
        //print(cube.transform.eulerAngles);

    }
    void mirror(GameObject player, GameObject cube)
    {
        Vector3 playerPos = player.transform.position;
        Vector3 cubePos = cube.transform.position;
        Vector3 playerOffSet = playerPos - previousPlayerPos;
        cube.transform.position = cubePos - playerOffSet;

        Vector3 playerRot = Pcamera.transform.eulerAngles;
        Vector3 rOffSet = -prevPlayerRot + playerRot;
        Vector3 cubeRot = cube.transform.eulerAngles;
        cube.transform.eulerAngles = cubeRot - rOffSet;


        prevPlayerRot = Pcamera.transform.eulerAngles;
        //print(prevPlayerRot);
        //print(cube.transform.eulerAngles);

        previousPlayerPos = playerPos;
        previousCubePos = cubePos;
    }
    void flip(GameObject cube)
    {
        transform.rotation *= Quaternion.Euler(0, 180, 0);

    }
    // Update is called once per frame
    void Update () {

        //match(player, cube);
        //mirror(player, cube);
        if (mPressed == false && Input.GetKeyDown(KeyCode.M))
        {
            previousPlayerPos = player.transform.position;
            prevPlayerRot = Pcamera.transform.eulerAngles;
            previousCubePos = cube.transform.position;
            mPressed = true;
        }


        if (mPressed)
        {
            if (Input.GetKeyDown(KeyCode.M) && count>0)
            {
                print("pressed");
                m = m * -1;
                cube.transform.localRotation *= Quaternion.Euler(0, 180, 0);
            }
            if (m < 0)
            {
                print("match");
                match(player, cube);
            }
            else
            {
                print("mirror");
                mirror(player, cube);
            }
            count = 1;
        }
	}
}
