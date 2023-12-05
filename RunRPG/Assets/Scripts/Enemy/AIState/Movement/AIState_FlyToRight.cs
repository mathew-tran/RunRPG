using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState_FlyToRight : AIState {

    public float mSpeed = 0.1f;
    public float mXMax = 1.0f;

    public override void DoRunStateAction(EnemyBase enemy)
    {
        if (enemy.transform.position.x < mXMax)
        {
            enemy.transform.Translate(Vector3.right * Time.deltaTime * mSpeed);
        }
        else
        {
            ReEnqueue(enemy);
        }
    }

    public override void DoVariableResets(EnemyBase enemy)
    {

    }
}
