using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour {

    // Use this for initialization
    public int mLevel;
    public static LevelData LevelDataMaster;

	void Start ()
    {
        if(!LevelDataMaster)
        {
            LevelDataMaster = this;
        }	
        if(LevelDataMaster != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
    
	void Update () {
		
	}
}
