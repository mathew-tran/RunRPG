using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_OnShot_BonusDamage : Skill_Impl {

    // Use this for initialization
    public int mCharges = 3;
    public int mMaxCharges = 3;
    public override void ApplySkill()
    {
        mCharges--;
        if (mCharges <= 0)
        {
            GameObject go = GameObject.Find("PlayerBulletsManager");
            PlayerBullet[] bullets = go.GetComponentsInChildren<PlayerBullet>();
            if(bullets.Length != 0)
            {
                PlayerBullet bullet = bullets[bullets.Length - 1];
                bullet.GetComponent<PlayerBullet>().AddDamage(1);
                bullet.GetComponent<SpriteRenderer>().color = Color.red;
                //Debug.Log("Bullet will do:  " + go.GetComponent<PlayerBullet>().GetDamage());
                mCharges = mMaxCharges;
            }
           
        }
    }
}
