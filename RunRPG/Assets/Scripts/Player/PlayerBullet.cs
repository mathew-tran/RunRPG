using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {

    public int mDamage = 1;
    public int GetDamage()
    {
        return mDamage;
    }
    public void SetDamage(int damage)
    {
        mDamage = damage;
    }
    public void AddDamage(int damage)
    {
        mDamage += damage;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
