using UnityEngine;
using System.Collections;

[System.Serializable]
abstract public class Weapon : MonoBehaviour {

    public float mMaxCoolDown = 2.0f;
    private float mCurrentCoolDown = 0.0f;
    public float mShootCost = 20.0f;

    private bool mCanShoot = true;
    public GameObject mBullet;
    private int mDamage = 1;
    
    // Use this for initialization

    public bool GetButtonPressType()
    {
        return Input.GetMouseButtonDown(0);
    }
    abstract public void WeaponUpdate();
    public float GetCost()
    {
        return mShootCost;
    }
    public void SetCost(float point)
    {
        mShootCost = point;
    }
    public void SetDamage(int dmg)
    {
        mDamage = dmg;
    }
    public int GetDamage()
    {
        return mDamage;
    }
    public bool CanShoot()
    {
        return mCanShoot;
    }
    public float GetCurrentCoolDown()
    {
        return mCurrentCoolDown;
    }
    public float GetMaxCoolDown()
    {
        return mMaxCoolDown;
    }
	void Awake () {
        mCanShoot = true;
       
    }
    IEnumerator ShootCoolDown()
    {
        while(mCurrentCoolDown > 0.0f)
        {
            mCurrentCoolDown -= Time.deltaTime;
            yield return null;
        }
        mCanShoot = true;
    }
    public void Shoot()
    {
        if (mCanShoot)
        {
            GameObject go = Instantiate(mBullet, gameObject.transform.position, Quaternion.identity);
            go.GetComponent<PlayerBullet>().SetDamage(mDamage);
            go.transform.SetParent(GameObject.Find("PlayerBulletsManager").transform);
            mCanShoot = false;
            mCurrentCoolDown = mMaxCoolDown;
            StartCoroutine("ShootCoolDown");
        }
    }
}
