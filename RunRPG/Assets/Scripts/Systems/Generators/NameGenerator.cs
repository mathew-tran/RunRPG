using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameGenerator : MonoBehaviour {

    // Use this for initialization
    public string[] mFoods;
    public string[] mBodyParts;

    public string mName = "NULL";
	public void GenerateName()
    {
        string firstName = mFoods[Random.Range(0, mFoods.Length)];
        string lastName = mBodyParts[Random.Range(0, mBodyParts.Length)];
        mName = firstName + " " + lastName;
    }
    public string GetName()
    {
        return mName;
    }
}
