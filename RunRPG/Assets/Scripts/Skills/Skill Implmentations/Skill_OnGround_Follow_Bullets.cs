using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_OnGround_Follow_Bullets : Skill_Impl
{

    // Use this for initialization
    public float mSpeed = 6.0f;
    public override void ApplySkill()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("BULLET");
        GameObject enemy = GameObject.FindGameObjectWithTag("ENEMY");

        if (objs != null && enemy != null)
        {
            foreach (GameObject obj in objs)
            {
                if (objs != null && enemy != null)
                {
                    obj.transform.position = Vector3.MoveTowards(obj.transform.position, enemy.transform.position, Time.deltaTime * mSpeed);
                }
                else
                {
                    break;
                }
            }
        }
	}
}
