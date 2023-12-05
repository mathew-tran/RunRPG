using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_OnStat_StrongJetPack : Skill_Impl {

    public override void ApplySkill()
    {
        ReferenceHelper.GetPlayer().AddJetPackForce(8.0f);
        
    }
}
