using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lighttrigger : MonoBehaviour {
	public GameObject object0;
	public GameObject object1;
	public GameObject object2;
	public GameObject object3;
	public Text scoreText;
	float elapsed = 0f;
	int num = 0;
	int prev = 0;
	int score = 0;
	// Use this for initialization
	void Start () {
		num = (int)Random.Range(0.0f, 3.0f);
		prev = num;
		object0 = GameObject.Find("object0");
		object1 = GameObject.Find("object1");
		object2 = GameObject.Find("object2");
		object3 = GameObject.Find("object3");
		turnLightOff(object0);
		turnLightOff(object1);
		turnLightOff(object2);
		turnLightOff(object3);
		scoreText.text = "Score:" + score;
	}
	void choose(int num){
		if(num == 0){
			turnLightOn(object0);
		}
		if(num == 1){
			turnLightOn(object1);
		}
		if(num == 2){
			turnLightOn(object2);
		}
		if(num == 3){
			turnLightOn(object3);
		}
		prev = num;		
	}
	void chooseOff(int num){
		if(num == 0){
			turnLightOff(object0);
		}
		if(num == 1){
			turnLightOff(object1);
		}
		if(num == 2){
			turnLightOff(object2);
		}
		if(num == 3){
			turnLightOff(object3);
		}
		
	}
	void turnLightOn(GameObject other){
		Light pl = other.transform.Find("pl").GetComponent<Light>();
		pl.color = Color.white;
	}
	void turnLightOff(GameObject other){
		Light pl = other.transform.Find("pl").GetComponent<Light>();
		pl.color = Color.black;
	}
	void OnTriggerStay(Collider other){
		if(Input.GetKeyDown("A Button")){
		//if(Input.GetKeyDown("s")){
			if(other.gameObject.name == "object0" && num == 0){
				Light pl = object0.transform.Find("pl").GetComponent<Light>();
				pl.color = Color.black;
				elapsed = 0f;
				score+=1;
				num = getNextTrigger(prev);
				choose(num);
				scoreText.text = "Score:" + score;
			}
			else if (other.gameObject.name == "object1" && num == 1) {
				Light pl = object1.transform.Find("pl").GetComponent<Light>();
				pl.color = Color.black;
				elapsed = 0f;
				score+=1;
				num = getNextTrigger(prev);
				choose(num);
				scoreText.text = "Score:" + score;

			}
			else if (other.gameObject.name == "object2" && num == 2) {
				Light pl = object2.transform.Find("pl").GetComponent<Light>();
				pl.color = Color.black;
				elapsed = 0f;
				score+=1;
				num = getNextTrigger(prev);
				choose(num);
				scoreText.text = "Score:" + score;

			}
			else if (other.gameObject.name == "object3" && num == 3) {
				Light pl = object3.transform.Find("pl").GetComponent<Light>();
				pl.color = Color.black;
				elapsed = 0f;
				score+=1;
				num = getNextTrigger(prev);
				choose(num);
				scoreText.text = "Score:" + score;

			}

		}
	}
	
	// Update is called once per frame
	void Update () {
		elapsed += Time.deltaTime;
		if(elapsed >= 3){
			chooseOff(num);
			num = getNextTrigger(prev);
			choose(num);

			elapsed = 0f;
		}
		
		if(Input.GetKeyDown("Start Button")){
		//if(Input.GetKeyDown("l")){
			#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
			#else
				Application.Quit();
			#endif
		}
		
	}
	
	int getNextTrigger(int prev) {
		// random trigger
		while (true) {
			num = (int)Random.Range(0.0f, 3.0f);
			if(num != prev){
				//prev = num;
				return num;
			}
		}	
	}
}
