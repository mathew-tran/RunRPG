using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_OffGround_RegenEnergy : Skill_Impl {

    // Use this for initialization
    public float mCost = 1.0f;
    public override void ApplySkill()
    {
        Player playerReference = ReferenceHelper.GetPlayer();
        playerReference.AddEnergy(mCost * Time.deltaTime);
    }
	
}
