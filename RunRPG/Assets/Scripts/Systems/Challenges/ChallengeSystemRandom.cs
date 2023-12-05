using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeSystemRandom : ChallengeSystemBase {

    public enum DIFFICULTY
    {
        VERYEASY = 100,
        EASY = 200,
        NORMAL = 400,
        MEDIUM = 600,
        HARD = 900,
        VERYHARD = 1200,
        HELL = 1500
    }
    
    // Use this for initialization

    public DIFFICULTY mDifficulty;
    public bool mWillForceEnemy = false;
    public GameObject mForcedEnemy;
    public override void CreateChallenge()
    {
        // Define a random difficulty setting.

        //var vals = System.Enum.GetValues(typeof(DIFFICULTY));
       // mDifficulty = (DIFFICULTY)vals.GetValue(Random.Range(0, vals.Length));

        // Set bonus pot according to difficulty setting,
        // This gives players extra cash if they beat the challenge

        // Sort list of enemies based on points
        mEnemyPool.Sort((x, y) => { return x.GetComponent<EnemyBase>().mPoints.CompareTo(y.GetComponent<EnemyBase>().mPoints); });


        // Define lowest amount of points and index.

        mLowestEnemyPoint = mEnemyPool[0].GetComponent<EnemyBase>().mPoints;
        // Set amount of points (representing the difficulty of the challenge)

        mMaxPoints = (int)mDifficulty;

        mCurrentPoints = mMaxPoints;

        mPrizeCoinPot = 0;
        mPrizePointPot = 0;
        
        while (mCurrentPoints != 0 && mCurrentPoints >= mLowestEnemyPoint && mEnemyPool.Count != 0)
        {
            if (mWillForceEnemy)
            {
                mEnemiesToSpawn.Add(mForcedEnemy);
            }
            else
            {
                mEnemyPool.RemoveAll((x => x.GetComponent<EnemyBase>().mPoints > mCurrentPoints));
                mEnemiesToSpawn.Add(mEnemyPool[Random.Range(0, mEnemyPool.Count - 1)]);
            }
            mCurrentPoints -= mEnemiesToSpawn[mEnemiesToSpawn.Count - 1].GetComponent<EnemyBase>().mPoints;
            mPrizeCoinPot += mEnemiesToSpawn[mEnemiesToSpawn.Count - 1].GetComponent<EnemyBase>().mPoints / 5;
        }
        ReferenceHelper.GetTrackManager().SetMaxProgress(mEnemiesToSpawn.Count * mTimeIntervalBetweenEnemies + 0.25f);
        mPrizePointPot = (int)mDifficulty * 100;

        // Grab random enemies, for each enemy, reduce the points by the enemies points
        // continue until points are 0 or less than lowest amount of points.

        // if points is at lowest amount of points, use the enemy index.


    }

    public override void StartChallenge()
    {
        EnemySpawner spawnref = ReferenceHelper.GetEnemySpawner();

        spawnref.Clear();

        // Adjust time, add X second interval between each enemy

        spawnref.SetIntervals(mTimeIntervalBetweenEnemies);

        foreach(GameObject obj in mEnemiesToSpawn)
        {
            spawnref.AddEnemy(obj);
        }

        // Add enemies to enemy spawner.

        spawnref.Setup();


        // Start spawner     

    }   
    public void Setup()
    {
        CreateChallenge();
        StartChallenge();
        AddPrize();
    }
	public override void Start () {
        
	}
    public override void AddPrize()
    {
        GameObject go = new GameObject();

        go.name = mDifficulty.ToString() + " challenge reward: " + mPrizeCoinPot.ToString();
        go.AddComponent<ChallengeReward>();
        go.GetComponent<ChallengeReward>().SetCoinAmount(mPrizeCoinPot);
        go.GetComponent<ChallengeReward>().SetPointAmount(mPrizePointPot);
        go.transform.SetParent(GameObject.Find("Rewards").transform);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
