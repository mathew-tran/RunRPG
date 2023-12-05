using UnityEngine;
using System.Collections;

public class Skill_STAT_WeaponEfficiencyI : Skill_Impl
{

    public override void ApplySkill()
    {
        Player playerReference = ReferenceHelper.GetPlayer();
        float shootCost = playerReference.GetShootCost();
        playerReference.SetShootCost(shootCost * 0.7f);
    }
}
