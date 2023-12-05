using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_OnKill_QuickLearner : Skill_Impl
{

    // Use this for initialization
    public int mExp = 10;
    public override void ApplySkill()
    {
        ReferenceHelper.GetPlayer().GetLevelingComponent().AddExperience(mExp);
        GameHelper.AddMessage("(" + mExp + ") bonus EXP!");
    }
	
}
