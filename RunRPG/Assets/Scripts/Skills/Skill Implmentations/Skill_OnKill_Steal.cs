using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_OnKill_Steal : Skill_Impl
{
    public int mChance = 25;
    public override void ApplySkill()
    {
        int roll = Random.Range(mChance, 100);
        if(roll >= mChance)
        {
            ReferenceHelper.GetCoinManager().AddCoins(1);
            GameHelper.AddMessage("Player stole a coin");
        }
    }
   
}
