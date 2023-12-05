using UnityEngine;
using System.Collections;

public class TrackManager : MonoBehaviour {

    public float mCurrentProgress = 0.0f;
    public float mMaxProgress = 30.0f;

    public bool mCanProgress;
    public bool mIsFinished = false;
	// Use this for initialization

	void Start () {
        mCurrentProgress = 0.0f;
        mIsFinished = false;
	}
	public void SetMaxProgress(float f)
    {
        mMaxProgress = f;
    }
    public float GetCurrentProgress()
    {
        return mCurrentProgress;
    }
    public float GetMaxProgress()
    {
        return mMaxProgress;
    }
    public bool IsTrackRunning()
    {
        return !mIsFinished && mCanProgress;
    }
	// Update is called once per frame
	void Update () {
	
        if (mCanProgress)
        {
            if(mCurrentProgress < mMaxProgress)
            {
                mCurrentProgress += Time.deltaTime;
                GameHelper.AddPlayerExperience(.05f);
                GameHelper.AddPoints(1);
            }
            else
            {
                mCanProgress = true;
                mIsFinished = false;
                mCurrentProgress = 0.0f;
                //ReferenceHelper.GetEnemySpawner().Restart();
            }
            

        }
	}
    public void ContinueProgress()
    {
        mCanProgress = true;
    }
    public void StopProgress()
    {
        mCanProgress = false;
    }
}
