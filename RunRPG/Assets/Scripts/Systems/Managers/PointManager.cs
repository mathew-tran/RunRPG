using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour {

    public int mCurrentPoints;
    public int mPoints;
    public int mPointsRate;
    private int mExchangeRate;

    public bool mIsCalculating = false;
	// Use this for initialization
	void Start () {
        mPointsRate = 100;	
	}
	
	// Update is called once per frame
    public bool IsCalculating()
    {
        return mIsCalculating;
    }
	void Update () {
		if(mPoints >= mExchangeRate)
        {
            
            mCurrentPoints += mExchangeRate;
            mPoints -= mExchangeRate;
            mIsCalculating = true;
        }
        else if(mPoints >= 5)
        {
            mCurrentPoints += 5;
            mPoints -= 5;
            mIsCalculating = true;
        }
        else
        {
            mIsCalculating = false;
        }
	}
    public void AddPoints(int points)
    {
        mPoints += points;
        mExchangeRate = mPoints / 5;
        if(mExchangeRate < 5 || mExchangeRate % 5 != 0)
        {
            mExchangeRate = 5;
        }
    }
    public int GetPoints()
    {
        return mCurrentPoints;
    }
}
