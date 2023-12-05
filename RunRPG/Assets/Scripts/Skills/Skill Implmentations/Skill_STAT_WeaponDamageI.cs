using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_STAT_WeaponDamageI : Skill_Impl
{

    public override void ApplySkill()
    {
        Weapon weaponReference = ReferenceHelper.GetPlayer().GetWeapon();
        weaponReference.SetDamage(weaponReference.GetDamage() + 1);
    }
}
