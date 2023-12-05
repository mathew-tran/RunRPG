using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_OnKill_MultipleRegenEnergy : Skill_Impl {

    public int mCharge = 1;
    public int mMaxCharge = 5;

    public float mTime = 0.0f;
    public float mMaxTime = 4.0f;

    public bool mCharging = false;
    public override void DoSetup()
    {
        mCharge = mMaxCharge;
        mTime = mMaxTime;
        mCharging = false;
    }
    public override void ApplySkill()
    {
        mCharge--;
        if (mCharge <= 0)
        {
            
            GameHelper.AddMessage(GameHelper.GetName() + " salvaged energy!");
            mCharge = mMaxCharge;   
            mCharging = true;
            mTime = mMaxTime;
        }
        
    }
    public void Update()
    {
        if (mCharging)
        {
            mTime -= Time.deltaTime;
            if (mTime <= 0.0f)
            {
                mCharging = false;
            }
            Player playerReference = ReferenceHelper.GetPlayer();
            playerReference.AddEnergy(playerReference.GetMaxEnergy());
        }
    }
}
