using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState_SpawnRadialObjects : AIState
{
    public GameObject mRadialObject;
    public int mSeparations = 1;
    public float mInitialRotation = 0.0f;
    // Use this for initialization
    public override void DoRunStateAction(EnemyBase enemy)
    {
       float slice = 360.0f / mSeparations;
        
        for(int i = 0; i < mSeparations; ++i)
        {
            GameObject obj = Instantiate(mRadialObject, enemy.transform.position, Quaternion.identity);
            float calcRot = slice * i + mInitialRotation;
            obj.GetComponent<RadialMover>().SetRotation(calcRot);
        }
        ReEnqueue(enemy);
    }

    // Update is called once per frame
    public override void DoVariableResets(EnemyBase enemy)
    {

    }
}
