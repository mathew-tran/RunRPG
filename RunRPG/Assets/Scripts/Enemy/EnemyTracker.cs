using UnityEngine;
using System.Collections;

public class EnemyTracker : MonoBehaviour {

    // Use this for initialization
    public float mCurrentTime = 0.0f;
    public float mMaxTime = 2.5f;
	void Start ()
    {
        ReferenceHelper.GetBlockSpawner().ForceBlockSpawn(ReferenceHelper.GetBlockRepo().Block);
    }
	
	// Update is called once per frame
	void Update ()
    {
        mCurrentTime += Time.deltaTime;
        if(!GameHelper.IsPlayerAlive())
        {
            Destroy(gameObject);
        }
        if(mCurrentTime >= mMaxTime)
        {
            if(!GameHelper.AreEnemiesOnScreen())
            {
                ReferenceHelper.GetTrackManager().ContinueProgress();
                ReferenceHelper.GetBlockSpawner().RemoveForceBlockSpawn();
                Destroy(gameObject);
            }
            mCurrentTime = 0;
        }
	}
}
