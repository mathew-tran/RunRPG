using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState_FlyToBottom : AIState {

    public float mSpeed = 0.1f;
    public float mYMin = 1.0f;

    // Use this for initialization
    public override void DoRunStateAction(EnemyBase enemy)
    {
        if (enemy.transform.position.y > mYMin)
        {
            enemy.transform.Translate(Vector3.down * Time.smoothDeltaTime * mSpeed);
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
