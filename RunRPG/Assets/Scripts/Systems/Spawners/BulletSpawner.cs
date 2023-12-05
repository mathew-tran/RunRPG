using UnityEngine;
using System.Collections;

public class BulletSpawner : SpawnerBase {

    public GameObject mBullet;

    public override void Setup()
    {
        mMaxIndex = 1; 
        mCanSpawn = true;
        mUseCoroutine = true;
        mCurrentSpawnTime = 0.0f;
        
    }
    public override void DoSpawnAction()
    {
        Instantiate(mBullet, new Vector3(mSpawnOrigin.x,mSpawnOrigin.y,0.0f) + gameObject.transform.position, Quaternion.identity);
    }

}
