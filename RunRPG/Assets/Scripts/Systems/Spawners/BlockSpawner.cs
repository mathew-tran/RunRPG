using UnityEngine;
using System.Collections;

public class BlockSpawner : SpawnerBase {

    public GameObject[] mBlockGroups;
    public GameObject mForcedBlock;
    
    public bool mForceBlockSpawning;
    private Transform mBlockHolderTransform;
    
    public override void Setup() {
        mBlockHolderTransform = GameObject.Find("BlockHolder").transform;
        mMaxIndex = mBlockGroups.Length;
        mForceBlockSpawning = false;
        mUseCoroutine = true;
    }

    public void SetSpawnerActivity(bool value)
    {
        mCanSpawn = value;
        if(mCanSpawn == false)
        {
            Mover[] movers = GameObject.FindObjectsOfType<Mover>();
            foreach(Mover move in movers)
            {
                if (move.name.Contains("Bullet") == false)
                {
                    move.mSpeed = 0.0f;
                }
            }
        }
    }

    override public void DoSpawnAction()
    {
        GameObject obj;
        if (mForceBlockSpawning)
        {
            obj = Instantiate(mForcedBlock, mSpawnOrigin, Quaternion.identity);
        }
        else
        {
            obj = Instantiate(mBlockGroups[mCurrentIndex], mSpawnOrigin, Quaternion.identity);
        }

        obj.transform.SetParent(mBlockHolderTransform);
    }
    public void ForceBlockSpawn(GameObject obj)
    {
        mForceBlockSpawning = true;
        mForcedBlock = obj;
    }
    public void RemoveForceBlockSpawn()
    {
        mForceBlockSpawning = false;
    }

}
