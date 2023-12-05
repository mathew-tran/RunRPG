using UnityEngine;
using System.Collections;

public class AIState : MonoBehaviour
{
    private bool hasFlushed = false;
    public void SetToFlush()
    {
        hasFlushed = false;
    }
    public void RunState(EnemyBase enemy)
    {
        if(!hasFlushed)
        {
            DoVariableResets(enemy);
            hasFlushed = true;
        }
        DoRunStateAction(enemy);
    }
    public virtual void DoRunStateAction(EnemyBase enemy)
    {
        
    }
    // needs to have an escape clause
    public virtual void DoVariableResets(EnemyBase enemy)
    {
    }
    public void ReEnqueue(EnemyBase enemy)
    {
        hasFlushed = false;
        enemy.mQueueStates.Add(enemy.mQueueStates[0]);
        enemy.mQueueStates.RemoveAt(0);
        enemy.mAIRef = null;        
    }

}
