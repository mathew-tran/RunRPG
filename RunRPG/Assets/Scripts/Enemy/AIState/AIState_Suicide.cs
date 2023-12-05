using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState_Suicide : AIState {

    // Use this for initialization
    public bool mHasSet = false;
    public float mSpeed = 8.0f;
    public override void DoRunStateAction(EnemyBase enemy)
    {
        if (!mHasSet)
        {
            mHasSet = true;
            enemy.SetHealth(1);
        }
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, ReferenceHelper.GetPlayer().transform.position, Time.deltaTime * mSpeed);
    }

    public override void DoVariableResets(EnemyBase enemy)
    {
        mHasSet = false;
    }
}
