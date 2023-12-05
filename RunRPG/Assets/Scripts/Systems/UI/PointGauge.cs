using UnityEngine;
using System.Collections;

public class PointGauge : MonoBehaviour {

    public int mPointAmount = 0;
    public int mPointIncreaseAmount = 2;
    public float mMaxPointIncrementTime = .25f;
    private float mCurrentPointIncrementTime = 0.0f;
    public bool mCanAccumulate = false;
	// Use this for initialization

    public int GetPointAmount()
    {
        return mPointAmount;
    }
    public void AddPoints(int amount)
    {
        mPointAmount += amount;
    }
    public void EnablePointAccumulation(bool value)
    {
        mCanAccumulate = value;
    }
	void Start ()
    {
        mCanAccumulate = false;
        mCurrentPointIncrementTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (mCanAccumulate)
        {
            mCurrentPointIncrementTime -= Time.deltaTime;
            if (mCurrentPointIncrementTime < 0.0f)
            {
                mPointAmount += mPointIncreaseAmount;
                mCurrentPointIncrementTime = mMaxPointIncrementTime;
            }
        }
	}
}
