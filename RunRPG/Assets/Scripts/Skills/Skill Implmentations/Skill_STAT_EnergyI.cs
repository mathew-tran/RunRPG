using UnityEngine;
using System.Collections;
using System;

public class Skill_STAT_EnergyI : Skill_Impl
{
    public override void ApplySkill()
    {
        Player playerReference = ReferenceHelper.GetPlayer();
        float maxEnergy = playerReference.GetMaxEnergy();
        playerReference.SetMaxEnergy(maxEnergy * 1.20f);

    }
}
