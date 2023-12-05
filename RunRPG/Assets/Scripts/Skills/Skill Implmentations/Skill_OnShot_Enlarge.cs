using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_OnShot_Enlarge : Skill_Impl
{

    public override void ApplySkill()
    {
        GameObject go = GameObject.Find("PlayerBulletsManager");
        PlayerBullet[] bullets = go.GetComponentsInChildren<PlayerBullet>();
        if (bullets.Length != 0)
        {
            PlayerBullet bullet = bullets[bullets.Length - 1];
            bullet.GetComponent<Transform>().localScale *= 1.5f;
        }        
    }
}
