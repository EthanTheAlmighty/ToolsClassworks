﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UEEexample : MonoBehaviour {

    public UnityEvent EventsToTrigger;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EventsToTrigger.Invoke();
        }
    }

    public void Foo()
    {
        Debug.Log("Stuff");
    }
}