using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopLevelManager : MonoBehaviour
{

    public int mLevel = 0;
    public float mPointsTowardsLevel = 0;
    public float mMaxPointsTowardsLevel = 1000;
    public float mDefaultPointsTowardsLevel = 1000;
    public static ShopLevelManager MasterCoinManager;

    // Use this for initialization
    public void Start()
    {
        if (!MasterCoinManager)
        {
            MasterCoinManager = this;
        }
        if (MasterCoinManager != this)
        {
            Destroy(gameObject);
        }
        if (ReferenceHelper.GetGameControl().Load())
        {
            mLevel = ReferenceHelper.GetGameControl().GetLevel();
            mPointsTowardsLevel = ReferenceHelper.GetGameControl().GetPointsTowardsLevel();
            mMaxPointsTowardsLevel = ReferenceHelper.GetGameControl().GetMaxPointsTowardsLevel();
        }
    }

    // Update is called once per frame
    public void Reset()
    {
        mLevel = 0;
        mMaxPointsTowardsLevel = mDefaultPointsTowardsLevel;
        mPointsTowardsLevel = 0;
    }
    public void AddLevelPoints(int points)
    {
        mPointsTowardsLevel += points;

        while(mPointsTowardsLevel >= mMaxPointsTowardsLevel)
        {
            mLevel++;
            mPointsTowardsLevel -= mMaxPointsTowardsLevel;
            mMaxPointsTowardsLevel *= 1.05f;
        }
       
    }
    public float GetPointsTowardsLevel()
    {
        return mPointsTowardsLevel;
    }
    public float GetPointsTowardMaxLevel()
    {
        return mMaxPointsTowardsLevel;
    }
    public int GetLevel()
    {
        return mLevel;
    }
}
