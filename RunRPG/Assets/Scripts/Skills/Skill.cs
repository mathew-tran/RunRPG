using UnityEngine;
using System.Collections;

[System.Serializable]

public class Skill : MonoBehaviour {

    
    public string mName;
    public string mDescription = "NULL";
    public int mLevel;


    public GameObject[] mAttributes;


    public string GetSkillName()
    {
        return mName;
    }
    public string GetSkillDescription()
    {
        return mDescription;
    }
    public int GetLevel()
    {
        return mLevel;
    }

    public void GiveSkill()
    {
        for (int i = 0; i < mAttributes.Length; ++i)
        {
            switch(mAttributes[i].GetComponent<Skill_Impl>().GetSkillType())
            {
                
                case Skill_Impl.SkillType.STAT:
                    mAttributes[i].GetComponent<Skill_Impl>().ApplySkill();
                    break;

                case Skill_Impl.SkillType.ONHIT:
                    ReferenceHelper.GetOnHitEvent().AddEventObject(mAttributes[i]);
                    break;

                case Skill_Impl.SkillType.OFFGROUND:
                    ReferenceHelper.GetOffGroundEvent().AddEventObject(mAttributes[i]);
                    break;

                case Skill_Impl.SkillType.ONKILL:
                    ReferenceHelper.GetOnKillEvent().AddEventObject(mAttributes[i]);
                    break;

                case Skill_Impl.SkillType.ONGROUND:
                    ReferenceHelper.GetOnGroundEvent().AddEventObject(mAttributes[i]);
                    break;

                case Skill_Impl.SkillType.ONSHOT:
                    ReferenceHelper.GetOnShotEvent().AddEventObject(mAttributes[i]);
                    break;

                case Skill_Impl.SkillType.ONHURT:
                    ReferenceHelper.GetOnHurtEvent().AddEventObject(mAttributes[i]);
                    break;

                case Skill_Impl.SkillType.ONJUMP:
                    ReferenceHelper.GetOnJumpAttackEvent().AddEventObject(mAttributes[i]);
                    break;

                case Skill_Impl.SkillType.NULL:
                    Debug.Break();
                    break;
                
            }
            
        }
        Debug.Log("NEW SKILL: " + mName);
    }

}
