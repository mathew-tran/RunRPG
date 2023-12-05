using UnityEngine;
using System.Collections;

public class Player : Damageable {

    [Header("Player")]
    public bool mCanMove;
    public bool mCanJump;

    [Header("JetPack")]
    private float mJetPackForce = 8.0f;
    private float mJetPackCost = 50.25f;

    [Header("Energy")]
    public float mMaxEnergy = 100.0f;
    public float mCurrentEnergy = 0.0f;    
    
    public float mRecoverRate = 25.0f;

    [Header("Restrictions")]
    public float mYDeadZone = -10.0f;

    float mMaxY = 1.0f;

    [Header("References")]
    private Weapon mWeapon;

    private Rigidbody2D mRB2d;

    public Vector2 mPlayerSpawnPoint;

    public Leveling mLevelingComponent;

    public SkillsCache mSkillsCache;

    public BoxCollider2D mBoxCollider;

    public SkillsCache GetSkillsCache()
    {
        return mSkillsCache;
    }
    public float GetShootCost()
    {
        return mWeapon.GetCost();
    }
    public void AddJetPackForce(float force)
    {
        mJetPackForce += force;
    }
    public void SetShootCost(float cost)
    {
        mWeapon.SetCost(cost);
    }

    public Leveling GetLevelingComponent()
    {
        return mLevelingComponent;
    }
    public Weapon GetWeapon()
    {
        return mWeapon;
    }
    public void AllowPlayerControl(bool value)
    {
        mCanMove = value;
    }
    public void SetMaxEnergy(float energy)
    {
        mMaxEnergy = energy;
    }
    public void AddEnergy(float energy)
    {
        mCurrentEnergy += energy;
        if(mCurrentEnergy >= mMaxEnergy)
        {
            mCurrentEnergy = mMaxEnergy;
        }
    }
    public void AddHealth(int Health)
    {
        mHealth += Health;
        if(mHealth >= mMaxHealth)
        {
            mHealth = mMaxHealth;
        }
    }
    public float GetMaxEnergy()
    {
        return mMaxEnergy;
    }
    public float GetCurrentEnergy()
    {
        return mCurrentEnergy;
    }
    public bool CanMove()
    {
        return mCanMove;
    }
    public bool CanJump()
    {
        return mCanJump;
    }
    public void SetKinematic(bool value)
    {
        mRB2d.isKinematic = value;
    }
    public void EnableControls(bool value)
    {
        mCanMove = value;
    }


    void Start()
    {
        
        mPlayerSpawnPoint = gameObject.transform.position;
        mSkillsCache = SkillsCache.SKillCacheMaster;
        GameObject.FindGameObjectWithTag("CACHE").GetComponent<SkillsCache>().Setup();
        ShopPackage.ShopPackageMaster.GiveToSkillCache();

        mWeapon = GameObject.Find("Weapon").GetComponent<Weapon>();
        mRB2d = GetComponent<Rigidbody2D>();
        mRB2d.isKinematic = true;

        mMaxHealth = mHealth;

        Debug.Assert(mLevelingComponent != null, "LEVELING COMPONENT FOR PLAYER IS NULL!");
        Debug.Assert(mSkillsCache != null, "SKILL CACHE COMPONENT FOR PLAYER IS NULL!");

    }
    public void ApplyPlayerSkills()
    {
        mSkillsCache.ApplySkills();
    }

	override public void DoUpdateAction()
    {
        if(mLevelingComponent.HasLevelChanged())
        {
            Debug.Log("- Leveled Up : " + mLevelingComponent.GetLevel() + " -");
            GameHelper.AddMessage("- " + GameHelper.GetName() + " is now level " + mLevelingComponent.GetLevel() + "! -");
            ApplyPlayerSkills();
            mLevelingComponent.CommitLeveledAction();
            GameHelper.AddPoints(1000 * mLevelingComponent.GetLevel());
            
            GameHelper.AddPoints(500);
        }
        if (mCanMove)
        {
            RunPlayerControls();
            RegenerateEnergy();
        }
	}
    void RunPlayerControls()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            UseJetPack();
        }

        if(mWeapon.GetButtonPressType())
        {
            Attack();
        }
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "WALL")
        {
            mCanJump = true;
        }        
    }
    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "WALL")
        {
            
            mCanJump = false;
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "ENEMY")
        {
            if (transform.position.y - mBoxCollider.size.y > coll.gameObject.transform.position.y)
            {
                coll.gameObject.GetComponent<EnemyBase>().TakeDamage(2);
                GameHelper.AddMessage(GameHelper.GetName() + " did a Jump Attack!");
                if (gameObject.transform.position.y <= mMaxY)
                {
                    mRB2d.AddForce(Vector2.up * mJetPackForce * 20.0f);
                    ReferenceHelper.GetUIManager().SetUIUpdate(true);
                }
                AddEnergy(10.0f);
                GameHelper.ActivateOnJumpEvent();
            }
            else
            {
                TakeDamage(1);
                if (coll.GetComponent<EnemyBase>().GetCurrentHealth() == 1)
                {
                    Destroy(coll.gameObject);
                }
            }           
        }
    }

    void SetPlayerToSpawnPoint()
    {
        gameObject.transform.position = mPlayerSpawnPoint;
    }
    void SnapToTop()
    {
          
        if (gameObject.transform.position.y >= mMaxY)
        {            
            mRB2d.AddForce(Vector2.down * mJetPackForce);
        }
    }
    void CheckGround()
    {
        float magnitude = .2f;
        Vector3 offset = new Vector3(0, -.2f, 0);
        RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position + offset, Vector2.right * magnitude);
        Debug.DrawRay(gameObject.transform.position + offset, Vector2.right * magnitude, Color.green);
        if (hit.collider != null)
        {
            if (hit.collider.tag == "WALL")
            {
                if (hit.distance <= magnitude)
                {
                    TakeDamage(1);
                    
                }
            }
        }
    }
    public void CheckZone()
    {
        if(transform.position.y <= mYDeadZone)
        {
            TakeDamage(1);
        }
    }
    void FixedUpdate()
    {
        SnapToTop();
        CheckGround();
        CheckZone();
    }

    override public void DoTakeDamageAction()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
        GameHelper.AddMessage(GameHelper.GetName() + " got hit for 1 damage!");
        GameHelper.ActivateOnHurtEvent();
        SetPlayerToSpawnPoint();
        mCurrentEnergy = mMaxEnergy;
        ReferenceHelper.GetUIManager().ShowPlayerHealth();
        if(!IsAlive())
        {
            Quaternion flip = gameObject.transform.rotation;
            flip.z = Random.Range(0, 360);
            gameObject.transform.rotation = flip;
            ReferenceHelper.GetGameManager().EndGame(GameManager.STATE.LOSE);
            Debug.Log("END GAME");
            GameHelper.AddMessage(GameHelper.GetName() + " is dead");
        }
        
    }
    void UseJetPack()
    {
        if(mCurrentEnergy > mJetPackCost * Time.deltaTime)
        {
            mCanJump = false;
            if (gameObject.transform.position.y <= mMaxY)
            {
                mRB2d.AddForce(Vector2.up * mJetPackForce);                
                ReferenceHelper.GetUIManager().SetUIUpdate(true);
            }
            mCurrentEnergy -= mJetPackCost * Time.deltaTime;
        }
    }

    void Attack()
    {
        if (mCurrentEnergy >= mWeapon.GetCost() && mWeapon.CanShoot())
        {
            mWeapon.Shoot();
            GameHelper.ActivateOnShotEvent();
            mCurrentEnergy -= mWeapon.GetCost();
        }  
    }

    void RegenerateEnergy()
    {
        if(mCanJump)
        {
            GameHelper.ActivateOnGroundEvent();
            if (mCurrentEnergy < mMaxEnergy)
            {
                mCurrentEnergy += mRecoverRate * Time.deltaTime;                
            }
            else
            {
                mCurrentEnergy = mMaxEnergy;
            }
        }
        else if(!mCanJump)
        {
            if (mCurrentEnergy < mMaxEnergy)
                GameHelper.ActivateOffGroundEvent();
        }
    }
}
