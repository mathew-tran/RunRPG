﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCampaign : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
    public void Load()
    {
        SceneManager.LoadScene("LevelOverworld");
    }
	// Update is called once per frame
	void Update () {
		
	}
}
