﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {
	
	void Start () {
		GetComponent<Rigidbody> ().velocity = new Vector3(-50,0,0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
