using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_OnHIT_RegainEnergy : Skill_Impl
{

    public override void ApplySkill()
    {
        Player playerReference = ReferenceHelper.GetPlayer();
        playerReference.AddEnergy(playerReference.GetShootCost() / 2);
    }
}
