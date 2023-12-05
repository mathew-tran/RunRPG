using UnityEngine;
using System.Collections;

abstract public class Skill_Impl : MonoBehaviour {

    // Use this for initialization
    public enum SkillType
    {
        STAT,
        ONHIT,
        ONKILL,
        ONGROUND,
        OFFGROUND, 
        ONSHOT,
        ONHURT,
        ONJUMP,
        NULL
    }
    public SkillType mSkillType = SkillType.NULL;

    public void Start()
    {
        
        DoSetup();
    }
    public virtual void DoSetup()
    {

    }
    public SkillType GetSkillType()
    {
        return mSkillType;
    }
    abstract public void ApplySkill();

}
