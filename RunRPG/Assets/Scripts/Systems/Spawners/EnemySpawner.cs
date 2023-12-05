using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class EnemySpawner : SpawnerBase {

    public TrackManager mTrackReference;

    public List<GameObject> mEnemies;
    public GameObject mEnemyTracker;

    public List<float> mSpawnTimes;
    public int mSpawnIndex;
    public float mIntervals = 5.0f;
    private float mCurrentInterval = 0.0f;

    // Use this for initialization
    public void SetIntervals(float f)
    {
        mIntervals = f;
    }
    public void AddEnemy(GameObject obj)
    {
        mEnemies.Add(obj);
    }
    public void Clear()
    {
        mSpawnTimes = new List<float>();
        mEnemies = new List<GameObject>();
    }
    public override void Setup()
    {
        mSpawnTimes = new List<float>();
        mCurrentInterval = 0.0f;
        mSpawnIndex = 0;
        mCurrentSpawnTime = 0.0f;
        
        mTrackReference = ReferenceHelper.GetTrackManager();
        foreach (GameObject obj in mEnemies)
        {
            mCurrentInterval += mIntervals;
            mSpawnTimes.Add(mCurrentInterval);
            
        }

        Debug.Assert(mSpawnTimes.Count > 0, "Expected Spawn Distances for enemies in enemy spawner");

        mMaxSpawnTime = mSpawnTimes[mSpawnIndex];
        //mSpawnTimes.Add(9999999.0f);        

        mMaxIndex = mEnemies.Count-1;
        mUseCoroutine = false;
        
    }
    public void Restart()
    {
        mSpawnIndex = 0;
        mCurrentSpawnTime = 0.0f;
        mMaxSpawnTime = mSpawnTimes[mSpawnIndex];
    }
    public override void DoUpdateActions()
    {
        if (!mCanSpawn && !GameHelper.AreEnemiesOnScreen() && GameHelper.IsTrackRunning())
        {
            mCurrentSpawnTime += Time.deltaTime;
            if (mCurrentSpawnTime > mMaxSpawnTime)
            {
                mCanSpawn = true;
            }
        }
    }
    // Update is called once per frame
    override public void DoSpawnAction()
    {
        mCanSpawn = false;

        if (mSpawnIndex > mEnemies.Count - 1)
        {
            ReferenceHelper.GetGameManager().EndGame(GameManager.STATE.WIN);
        }
        else
        {
            mMaxSpawnTime = mSpawnTimes[mSpawnIndex];
            ReferenceHelper.GetTrackManager().StopProgress();
            ReferenceHelper.GetBlockSpawner().ForceBlockSpawn(ReferenceHelper.GetBlockRepo().Block);
            Instantiate(mEnemies[mSpawnIndex], mSpawnOrigin, Quaternion.identity);
            Instantiate(mEnemyTracker, mSpawnOrigin, Quaternion.identity);
            mSpawnIndex++;
        }



    }

}
