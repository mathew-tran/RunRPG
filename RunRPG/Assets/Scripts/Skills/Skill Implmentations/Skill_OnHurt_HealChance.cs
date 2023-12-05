using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_OnHurt_HealChance : Skill_Impl
{
    public int mCharges = 1;
    public int mMaxCharges = 3;
    public override void DoSetup()
    {
        mCharges = mMaxCharges;
    }
    public override void ApplySkill()
    {
        GameHelper.AddMessage("Charges: " + mCharges);
        if (mCharges > 0)
        {
            int choice = Random.Range(0, 3);
            
            if (choice == 0)
            {                
                GameHelper.AddMessage(GameHelper.GetName() + " healed for 2 Health!");
                ReferenceHelper.GetPlayer().AddHealth(2);
                mCharges--;
                GameHelper.AddMessage("(" + mCharges + ") heal charges left!");
            }
        }
      
    }
}
