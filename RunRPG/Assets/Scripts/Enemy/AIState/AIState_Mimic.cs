using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState_Mimic : AIState {


    private Player mPlayerRef;
    private float mCurrentTime = 0.0f;

    [Range(1.0f,5.0f)]
    public float mMaxMimicTime = 2.0f;

    [Range(1.0f,5.0f)]
    public float mFollowSpeed = 2.0f;
    public override void DoRunStateAction(EnemyBase enemy)
    {
        mCurrentTime += Time.deltaTime;

        float yPlayerPos = mPlayerRef.transform.position.y;

        Vector3 targetPosition = enemy.transform.position;
        targetPosition.y = yPlayerPos;

        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, targetPosition, Time.deltaTime * mFollowSpeed);
        if(mCurrentTime >= mMaxMimicTime)
        {
            ReEnqueue(enemy);
        }
    }

    public override void DoVariableResets(EnemyBase enemy)
    {
        mPlayerRef = ReferenceHelper.GetPlayer();
        mCurrentTime = 0.0f;
        Debug.Assert(mCurrentTime < mMaxMimicTime);
    }
}
