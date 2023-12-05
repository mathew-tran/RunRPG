using UnityEngine;
using System.Collections;

public class Damageable : MonoBehaviour{

    public bool mIsHurt = false;
    [Header("Damageable")]
    public int mHealth;
    public int mMaxHealth;

    [Header("Explosion Prefabs")]
    public GameObject mSmallExplosionPrefab;
    public GameObject mBigExplosionPrefab;

    [Space(20)]
    protected float mITime = 0.0f;
    private float mMaxInvincibilityTime = .10f;
    

    public void RegenerateITime()
    {
        if (mIsHurt)
        {
            mITime += Time.deltaTime * 1.0f;
            if (mITime >= mMaxInvincibilityTime)
            {
                mIsHurt = false;
            }
        }
    }
    public void DetermineMaterial()
    {
        if (mIsHurt)
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 1);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        }
    }

    // Use this for initialization
    public int GetCurrentHealth()
    {
        return mHealth;
    }

    public int GetMaxHealth()
    {
        return mMaxHealth;
    }
    public void SetHealth(int amount)
    {
        mHealth = amount;
    }
    public bool IsAlive()
    {
        return mHealth > 0;
    }

    public void TakeDamage(int damage)
    {
        if (!mIsHurt)
        {
            if (IsAlive())
            {
                mIsHurt = true;
                mITime = 0.0f;
                mHealth -= damage;
                if(mHealth <= 0)
                {
                    Instantiate(mBigExplosionPrefab, transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(mSmallExplosionPrefab, transform.position, Quaternion.identity);
                }
                DoTakeDamageAction();
               
            }
            else
            {
               
            }
        }
    }

    public void Update()
    {
        DoUpdateAction();
        RegenerateITime();
        DetermineMaterial();
    }
    virtual public void DoUpdateAction()
    {

    }
    virtual public void DoTakeDamageAction()
    {

    }

}
