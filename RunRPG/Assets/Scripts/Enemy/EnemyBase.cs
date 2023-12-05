using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyBase : Damageable {

    [Header("EnemyBase")]
    // Use this for initialization
    public Sprite mSprite;

    public List<GameObject> mQueueStates;

    public AIState mAIRef = null;
    [Space(20)]

    [Range(10, 200)]
    public int mPoints = 100;

    [Range(0, 150)]
    public int mEXP = 25;

    void Start ()
    {
        if (mQueueStates.Count >= 1)
        {
            foreach(GameObject state in mQueueStates)
            {
                state.GetComponent<AIState>().SetToFlush();
            }
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "BULLET")
        {            
            TakeDamage(coll.GetComponent<PlayerBullet>().GetDamage());
            GameHelper.ActivateOnHitEvent();
            Destroy(coll.gameObject);
        }
    }

    override public void DoUpdateAction()
    {
        if (mQueueStates.Count >= 1 && GameHelper.IsPlayerAlive()) 
            DoAI();
    }

    public void DoAI()
    {
        if (mAIRef == null)
        {
            Debug.Assert(mQueueStates.Count != 0);
            mAIRef = mQueueStates[0].GetComponent<AIState>();
        }
        else
        {
            mAIRef.RunState(this);
        }
    }
    public void Destroy()
    {
        if (mQueueStates.Count >= 1)
            mQueueStates[0].GetComponent<AIState>().SetToFlush();
    }
    override public void DoTakeDamageAction()
    {
        if(!IsAlive())
        {
            GameHelper.ActivateOnKillEvent();
            GameHelper.AddPlayerExperience(mEXP);
            GameHelper.AddPoints(mPoints);
            GameHelper.AddMessage(GameHelper.GetName() + " gained (" + mEXP + ") EXP and (" + mPoints + ") points");
            Destroy(gameObject);
            
        }
    }

}
