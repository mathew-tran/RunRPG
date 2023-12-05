using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_OnKill_ExtraPoints : Skill_Impl {

    // Use this for initialization
    public int mPoints = 10;
    public override void ApplySkill()
    {
        GameHelper.AddMessage("(" + mPoints + ") bonus points!");
        GameHelper.AddPoints(mPoints);
    }
	
}
