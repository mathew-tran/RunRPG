using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_OnJump_EnergyRegen : Skill_Impl {

    // Use this for initialization
    public float mEnergyAmount = 20.0f;
    public override void ApplySkill()
    {
        GameHelper.AddMessage("Sapped Energy!");
        ReferenceHelper.GetPlayer().AddEnergy(mEnergyAmount);
    }
	
}
