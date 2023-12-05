using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadQuickPlay : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	public void Load()
    {
        SceneManager.LoadScene("QuickPlay");
        Transform[] trs = SkillsCache.SKillCacheMaster.GetComponentsInChildren<Transform>();
        foreach(Transform tr in trs)
        {
            Destroy(tr.gameObject);
        }
        

    }
	// Update is called once per frame
	void Update () {
		
	}
}
