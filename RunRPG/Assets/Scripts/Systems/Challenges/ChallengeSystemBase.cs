using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeSystemBase : MonoBehaviour {

    public List<GameObject> mEnemyPool;

    public int mPrizeCoinPot;
    public int mPrizePointPot;
    public int mMaxPoints;
    public int mCurrentPoints;
    public int mLowestEnemyPoint = 0;
    public List<GameObject> mEnemiesToSpawn;
    public float mTimeIntervalBetweenEnemies;

    public virtual void CreateChallenge()
    {

    }
    public virtual void StartChallenge()
    {

    }
    public virtual void AddPrize()
    { 

    }
    // Use this for initialization
    public virtual void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
