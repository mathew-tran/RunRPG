using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_OnHurt_Reflect : Skill_Impl
{

    public override void ApplySkill()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("ENEMY");
        foreach(GameObject go in gos)
        {
            go.GetComponent<EnemyBase>().TakeDamage(3);
        }
        GameHelper.AddMessage(GameHelper.GetName() + " dealt damage to everyone in the room!");
    }
}
