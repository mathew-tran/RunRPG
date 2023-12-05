using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPackage : MonoBehaviour {

    // Use this for initialization
    public List<GameObject> mPackages;
    public ChallengeSystemRandom.DIFFICULTY mDifficulty;
    public static ShopPackage ShopPackageMaster;
	void Start () {        

        mPackages = new List<GameObject>();

        if (!ShopPackageMaster)
        {
            ShopPackageMaster = this;
            SetDifficulty();
        }
        if (ShopPackageMaster != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);     

    }
    public void SetDifficulty()
    {
        var vals = System.Enum.GetValues(typeof(ChallengeSystemRandom.DIFFICULTY));
        mDifficulty = (ChallengeSystemRandom.DIFFICULTY)vals.GetValue(Random.Range(0, vals.Length));
    }
    public bool DoesObjectExist(GameObject obj)
    {
        foreach(GameObject go in mPackages)
        {
            if(go != obj)
            {
                return false;
            }
        }
        return true;
    }
    public string GetPackageString()
    {
        string str = "Package Items: \n";
        foreach (GameObject go in mPackages)
        {
            string skillstr = go.GetComponent<Skill>().GetSkillName();
            str += skillstr + "\n";
        }
        return str;
    }
    private void AddStoreObject(GameObject obj)
    {
        GameObject ins = Instantiate(obj);
        mPackages.Add(ins);
        ins.transform.SetParent(gameObject.transform);
    }
    public void UpdatePackage()
    {
        PlayerShop pShop = GameObject.FindWithTag("SHOP").GetComponent<PlayerShop>();
        mPackages.Clear();

        foreach(Item itm in pShop.mItemList)
        {
            AddStoreObject(itm.mSkill);
        }
    }
    public void GiveToSkillCache()
    {
        ChallengeSystemRandom challenge = GameObject.Find("Challenge").GetComponent<ChallengeSystemRandom>();
        challenge.mDifficulty = mDifficulty;
        challenge.Setup();

        foreach (GameObject go in mPackages)
            SkillsCache.SKillCacheMaster.AddSkillObject(go);

        mPackages.Clear();
    }
	// Update is called once per frame
	void Update () {
        GameObject dText = GameObject.Find("DifficultyText");

        if (dText)
            dText.GetComponent<Text>().text = mDifficulty.ToString();
    }
}
