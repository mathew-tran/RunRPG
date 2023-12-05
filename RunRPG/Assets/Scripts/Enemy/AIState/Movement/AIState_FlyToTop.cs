using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState_FlyToTop : AIState
{

    public float mSpeed = 0.1f;
    public float mYMax = 1.0f;
    // Use this for initialization
    public override void DoRunStateAction(EnemyBase enemy)
    {
        if(enemy.transform.position.y < mYMax)
        {
            enemy.transform.Translate(Vector3.up * Time.smoothDeltaTime * mSpeed);
        }
        else
        {
            ReEnqueue(enemy);
        }
    }

    // Update is called once per frame
    public override void DoVariableResets(EnemyBase enemy)
    {

    }
}
