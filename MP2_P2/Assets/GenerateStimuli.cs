using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateStimuli : MonoBehaviour {
    public GameObject Red;
    public GameObject Blue1;
    public GameObject Blue2;
    public GameObject mainCamera;
    int a = -1;
    bool pressed = false;
    float rdR;
    float b1r;
    float b2r;
    // Use this for initialization
    void Start () {
        //Red.SetActive(false);
        //Blue1.SetActive(false);
        //Blue2.SetActive(false);
        rdR = Red.transform.localScale.x;
        //b1r = Blue1.transform.localScale.x;
        //b2r = Blue2.transform.localScale.x;
    }
    IEnumerator turnOn()
    {
        Red.SetActive(true);
        yield return new WaitForSeconds(2);
        Blue1.SetActive(true);
        Blue2.SetActive(true);
    }
    IEnumerator turnOff()
    {
        Red.SetActive(false);
        yield return new WaitForSeconds(2);
        Blue1.SetActive(false);
        Blue2.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.S))
        {
            pressed = true;
            a *= -1;

            if (a == 1)
            {
                StartCoroutine(turnOn());
            }
            else
            {
                StartCoroutine(turnOff());
            }
        }
        if(pressed == true)
        {
            float rdD = Vector3.Distance(Red.transform.position, mainCamera.transform.position);
            float b1D = Vector3.Distance(Blue1.transform.position, mainCamera.transform.position);
            float b2D = Vector3.Distance(Blue2.transform.position, mainCamera.transform.position);
            float b1 = rdR / rdD * b1D;
            float b2 = rdR / rdD * b2D;

            //float b1s_new 

           // Blue1.GetComponent<SphereCollider>().radius = rdR / rdD * b1D;
            //Blue2.GetComponent<SphereCollider>().radius = rdR / rdD * b2D;
            Blue1.transform.localScale = new Vector3(b1, b1, b1);
            Blue2.transform.localScale = new Vector3(b2, b2, b2);
        }
    }
}
