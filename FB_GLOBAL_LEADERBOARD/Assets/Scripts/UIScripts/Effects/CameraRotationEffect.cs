using UnityEngine;
using System.Collections;
using System;

public class CameraRotationEffect : MonoBehaviour {

	//public Time time;
	public GameObject mainCamera;
	// Use this for initialization
	void Start () {
		Time.fixedDeltaTime = 0.05f;
		mainCamera =  GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		mainCamera.transform.Rotate(0, 2 * Time.deltaTime, 0);
	}
}
