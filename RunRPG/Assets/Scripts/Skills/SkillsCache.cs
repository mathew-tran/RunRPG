using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillsCache : MonoBehaviour {

    public Leveling mLevelReference;
    public List<GameObject> mSkills;
    public static SkillsCache SKillCacheMaster;
	// Use this for initialization
	void Start ()
    {
        mSkills = new List<GameObject>();
        if (!SKillCacheMaster)
        {
            SKillCacheMaster = this;
        }
        if(SKillCacheMaster != this)
        {
            Destroy(gameObject);
        }
        gameObject.tag = "CACHE";
        DontDestroyOnLoad(gameObject);       
       
	}
    public void Setup()
    {
        mLevelReference = GameObject.Find("LevelManager").GetComponent<Leveling>();
        Debug.Assert(mLevelReference != null);
        
        //Debug.Assert(mSkills.Count != 0);
    }
    public void AddSkillObject(GameObject obj)
    {
        GameObject ins = Instantiate(obj);
        mSkills.Add(ins);
        ins.transform.SetParent(gameObject.transform);
    }
    public void ShowSkills()
    {
        
        if (mSkills.Count != 0)
        {
            GameHelper.AddMessage("SKILLS");
            List<int> arr = new List<int>();
            for (int i = 0; i < mSkills.Count; ++i)
            {
                arr.Add(mSkills[i].GetComponent<Skill>().GetLevel());
            }
            arr.Sort();
            for (int i = 0; i < arr.Count; ++i)
            {
                GameHelper.AddMessage(arr[i] + " ??? ");
            }
        }
        else
        {
            GameHelper.AddMessage("NO SKILLS");
        }
    }
    public void ApplySkills()
    {
        if (mSkills.Count != 0)
        {
            for (int i = 0; i < mSkills.Count; ++i)
            {
                if (mSkills[i].GetComponent<Skill>().GetLevel() <= mLevelReference.GetLevel())
                {
                    GameHelper.AddMessage("SKILL GAINED: " + mSkills[i].GetComponent<Skill>().GetSkillName());
                    GameHelper.AddMessage("> " + mSkills[i].GetComponent<Skill>().GetSkillDescription());
                    mSkills[i].GetComponent<Skill>().GiveSkill();
                    mSkills.RemoveAt(i);
                    i--;
                }
            }
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
