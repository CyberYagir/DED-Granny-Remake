﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon : MonoBehaviour {
    public GameObject Player;
	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(Player.transform.position);
	}
}
