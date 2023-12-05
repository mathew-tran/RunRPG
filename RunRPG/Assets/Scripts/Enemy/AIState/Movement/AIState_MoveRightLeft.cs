using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState_MoveRightLeft : AIState
{

    public float mSpeed = .1f;
    public float mXDeadZone = -2.0f;
    // Use this for initialization
    public override void DoRunStateAction(EnemyBase enemy)
    {
        enemy.transform.Translate(Vector3.left * Time.smoothDeltaTime * mSpeed);
        if(enemy.transform.position.x < mXDeadZone )
        {
            Destroy(enemy);
        }
    }
	
}
