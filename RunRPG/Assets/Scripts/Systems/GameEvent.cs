using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour {

    // Use this for initialization
    public string mEventString = "null";
    public List<GameObject> mEvents;
    public bool mDebugOn = false;
    public void AddEventObject(GameObject obj)
    {
        GameObject ins = Instantiate(obj);
        mEvents.Add(ins);
        ins.transform.SetParent(gameObject.transform);
    }
    public void Run()
    {
        if(mDebugOn)
            Debug.Log(mEventString + " event ran");
        foreach(GameObject evt in mEvents)
        {
            evt.GetComponent<Skill_Impl>().ApplySkill();
        }
    }
}
