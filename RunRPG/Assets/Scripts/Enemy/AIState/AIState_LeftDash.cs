using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState_LeftDash : AIState {

    // Use this for initialization
    public Vector3 mTargetPosition;
    public Vector3 mStartPosition;
    public float mEndX = -7.0f;
    public float mStartX;
    public float mSpeed = 6.0f;
    public override void DoRunStateAction(EnemyBase enemy)
    {
        if (enemy.transform.position.x > mEndX)
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, mTargetPosition, Time.deltaTime * mSpeed);
        }
        else
        {
            enemy.transform.position = mStartPosition;
            ReEnqueue(enemy);
        }
    }

    public override void DoVariableResets(EnemyBase enemy)
    {
        mTargetPosition = enemy.transform.position;
        mTargetPosition.x = mEndX;
        mStartPosition = enemy.transform.position;
    }
}
