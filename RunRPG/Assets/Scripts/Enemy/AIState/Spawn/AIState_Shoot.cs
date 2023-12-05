using UnityEngine;
using System.Collections;

public class AIState_Shoot : AIState
{
    private float mCurrentTimer = 0.0f;

    [Range(.20f, 9.0f)]
    public float mMaxTimer = 3.0f;

    [Header("Spawn Amount")]
    private int mSpawnAmount = 0;
    public int mMaxSpawnAmount = 1;
    public GameObject mBullet;
    public override void DoRunStateAction(EnemyBase enemy)
    {
        mCurrentTimer += Time.deltaTime;       
        if (mCurrentTimer >= mMaxTimer)
        {           
            if(GameHelper.GetEnemyAmount() < 20)
                Spawn(enemy);
            mCurrentTimer = 0.0f;
            mSpawnAmount++;
        }
        if(mSpawnAmount >= mMaxSpawnAmount)
        {
            ReEnqueue(enemy);
        }

    }
    public override void DoVariableResets(EnemyBase enemy)
    {
        mCurrentTimer = 0.0f;
        mSpawnAmount = 0;
    }
    void Spawn(EnemyBase enemy)
    {
        GameObject obj = Instantiate(mBullet, enemy.transform.position, Quaternion.identity) as GameObject;

        obj.transform.parent = null;
    }
}
