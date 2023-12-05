using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_OnJump_Steal : Skill_Impl
{
    public int mCoins = 5;
    public override void ApplySkill()
    {
        ReferenceHelper.GetCoinManager().AddCoins(mCoins);
        GameHelper.AddMessage(GameHelper.GetName() + " got " + mCoins.ToString() + " coin(s)");
    }
}
