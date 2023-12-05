using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_OnJump_PointsEXP : Skill_Impl {

    // Use this for initialization
    public int mPoints = 100;
    public int mExp = 10;
    public override void ApplySkill()
    {
        GameHelper.AddPoints(mPoints);
        GameHelper.AddPlayerExperience(mExp);
        GameHelper.AddMessage("Gain (" + mExp.ToString() + ") EXP and (" + mPoints.ToString() + ") points");
    }
}
