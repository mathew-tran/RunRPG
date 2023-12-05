using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState_FlyToMiddle : AIState {

    public float mSpeed = 0.1f;
    public float mXMin = 1.0f;

    public override void DoRunStateAction(EnemyBase enemy)
    {
        if(enemy.transform.position.x > mXMin)
        {
            enemy.transform.Translate(Vector3.left * Time.deltaTime * mSpeed);
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
