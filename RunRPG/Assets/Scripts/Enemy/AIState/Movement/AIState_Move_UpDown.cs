using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState_Move_UpDown : AIState {

    public float mYMin = -1.0f;
    public float mYMax = 1.0f;
    public float mSpeed = 0.1f;
    public bool isMovingDown = false;
    public float mStartY;
    public override void DoRunStateAction(EnemyBase enemy)
    {

        if (enemy.mIsHurt)
        {
            ReEnqueue(enemy);
        }

        if(isMovingDown)
            enemy.transform.Translate(Vector3.down * Time.smoothDeltaTime * mSpeed);
        else
            enemy.transform.Translate(Vector3.up * Time.smoothDeltaTime * mSpeed);

        if(enemy.transform.position.y > mYMax + mStartY)
        {
            isMovingDown = true;
        }
        else if(enemy.transform.position.y < mYMin + mStartY)
        {
            isMovingDown = false;
        }
       
    }
    public override void DoVariableResets(EnemyBase enemy)
    {
        mStartY = 1.0f;
    }
    public void Start()
    {
        mStartY = gameObject.transform.position.y;
    }
}
