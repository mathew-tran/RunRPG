using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_OnKill_Heal : Skill_Impl
{

    // Use this for initialization
    public int mCharges = 1;
    public int mMaxCharges = 1;
    public override void DoSetup()
    {
        mCharges = mMaxCharges;
    }
    public override void ApplySkill()
    {
        mCharges--;
        if(mCharges <= 0)
        {
            ReferenceHelper.GetPlayer().AddHealth(1);
            mCharges = mMaxCharges;
        }
    }
	

}
