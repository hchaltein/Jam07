﻿using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	public void LoadScene()
	{
		Application.LoadLevel("Boss Scene");
	}


    public void ExitLevel()
    {
        Application.Quit();
    }
}
