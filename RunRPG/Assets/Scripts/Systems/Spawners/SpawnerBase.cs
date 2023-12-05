using UnityEngine;
using System.Collections;

public class SpawnerBase : MonoBehaviour {

    // Use this for initialization
    public float mCurrentSpawnTime = 0.0f;
    public float mMaxSpawnTime = 5.0f;
    public Vector2 mSpawnOrigin;
    public bool mCanSpawn;
    public bool mUseCoroutine;

    public int mCurrentIndex;
    public int mMaxIndex;
    
    public virtual void Setup()
    {

    }
    public void Awake () {
        mCurrentIndex = 0;
        mCurrentSpawnTime = 0.0f;
        mCanSpawn = false;
        Setup();
        Debug.Assert(mCurrentIndex < mMaxIndex, "EXPECTED CURRENT INDEX IS LESS THAN MAX INDEX. MEANS THERE ARE NO OBJECTS TO SPAWN IN A SPAWNER DERIVED OBJECT");
    }
	
	// Update is called once per frame
	public void FixedUpdate ()
    {
        if (mCanSpawn)
        {
            Spawn();
            if(mUseCoroutine)
                StartCoroutine("SpawnCoolDown");
        }
        DoUpdateActions();
    }
    public virtual void DoUpdateActions()
    {

    }
    public IEnumerator SpawnCoolDown()
    {
        mCanSpawn = false;
        mCurrentSpawnTime = mMaxSpawnTime;
        while (mCurrentSpawnTime >= 0.0f)
        {
            mCurrentSpawnTime -= Time.deltaTime * 1.0f;
            yield return null;
        }
        mCanSpawn = true;

    }
    public void Spawn()
    {
        mCurrentIndex++;
        if (mCurrentIndex == mMaxIndex)
        {
            mCurrentIndex = 0;
        }
        DoSpawnAction();
    }
    public virtual void DoSpawnAction()
    {

    }
}
