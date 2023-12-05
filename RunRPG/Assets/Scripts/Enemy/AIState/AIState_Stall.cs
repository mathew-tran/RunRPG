using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState_Stall : AIState {

    public float mMaxTime = 1.0f;
    private float mCurrentTime = 1.0f;
    // Use this for initialization
    public override void DoRunStateAction(EnemyBase enemy)
    {
        mCurrentTime -= Time.deltaTime;
        if(mCurrentTime <= 0.0f)
        {
            ReEnqueue(enemy);
        }
    }

    // Update is called once per frame
    public override void DoVariableResets(EnemyBase enemy)
    {
        mCurrentTime = mMaxTime;
    }
}
