using UnityEngine;
using System.Collections;

[System.Serializable]
public class Leveling : MonoBehaviour {

    public int mLevel;

    private float mCurrentExperience;
    private float mMaxExperience;
    private float mExp;
    private float mExpRate = 0.5f;
    public float mLevelGrowthMultiplier = 1.1f;
    private bool mHasLeveled = false;
    public bool mIsCalculating = false;
    public bool IsCalculating()
    {
        return mIsCalculating;
    }
    public bool HasLevelChanged()
    {
        return mHasLeveled;
    }
    public void CommitLeveledAction()
    {
        mHasLeveled = false;
    }
    public int GetLevel()
    {
        return mLevel;
    }
    public void SetLevel(int level)
    {
        mLevel = level;
    }
    public void SetExperience(float exp, float maxexp)
    {
        mCurrentExperience = exp;
        mMaxExperience = maxexp;
    }
    void Update()
    {
        if(mExp >= mExpRate)
        {
            
            mCurrentExperience += mExpRate;
            mExp -= mExpRate;
            mIsCalculating = true;
            if (mCurrentExperience >= mMaxExperience)
            {
                mLevel++;
                mHasLeveled = true;
                mCurrentExperience = 0;
                mMaxExperience *= mLevelGrowthMultiplier;
            }
        }
        else
        {
            mIsCalculating = false;
        }
        
    }
    public void AddExperience(float exp)
    {
        mExp += exp;
       
        
    }
    public float GetCurrentExperience()
    {
        return mCurrentExperience;
    }
    public float GetMaxExperience()
    {
        return mMaxExperience;
    }
    void Start()
    {
        mHasLeveled = false;
        if(mMaxExperience <= 0)
        {
            mMaxExperience = 50;
        }
    }
}
