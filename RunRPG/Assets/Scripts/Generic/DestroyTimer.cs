using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour {

    float mMaxTime = 5.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        mMaxTime -= Time.deltaTime;

        if(mMaxTime <= 0.0f)
        {
            Destroy(gameObject);
        }
	}
}
