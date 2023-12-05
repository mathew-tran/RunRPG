using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_OnShot_IncreasedBulletSpeed : Skill_Impl {

    public float mSpeed = 20;

    public override void DoSetup()
    {
        mSpeed = 20;
    }
    public override void ApplySkill()
    {
        GameObject go = GameObject.Find("PlayerBulletsManager");
        PlayerBullet[] bullets = go.GetComponentsInChildren<PlayerBullet>();
        foreach(PlayerBullet bullet in bullets)
        {
            bullet.GetComponent<Mover>().mSpeed = mSpeed;
        }
        Debug.Log("Speed");
    }
}
