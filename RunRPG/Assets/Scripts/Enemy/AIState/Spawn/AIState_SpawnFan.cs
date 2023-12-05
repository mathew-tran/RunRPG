using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState_SpawnFan : AIState {

    public GameObject mRadialObject;
    [Range(1, 12)]
    public int mSeparations = 3;

    [Range(0.0f, 360.0f)]
    public float mInitialRotation = 0.0f;

    // Use this for initialization
    public override void DoRunStateAction(EnemyBase enemy)
    { 
        float slice = 180.0f / mSeparations;
        for(int i = 0; i < mSeparations; ++i)
        {
            GameObject obj = Instantiate(mRadialObject, enemy.transform.position, Quaternion.identity);
            float calcRot = slice/mSeparations * i + mInitialRotation;
            obj.GetComponent<RadialMover>().SetRotation(calcRot);
        }
        ReEnqueue(enemy);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
