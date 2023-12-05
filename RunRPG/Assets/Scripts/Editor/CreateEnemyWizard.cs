using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreateEnemyWizard : ScriptableWizard {

    public string enemyName;
    public int exp;
    public int points;
    public int health;

    public Sprite sprite;
    public List<GameObject> AIStates;

    public GameObject smallExplosion;
    public GameObject largeExplosion;

    [MenuItem ("My Tools/Create Enemy Wizard...")]
	static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard<CreateEnemyWizard>("Create Enemy", "Create new");
    }
    void OnWizardCreate()
    {
        GameObject enemyGO = new GameObject();
        EnemyBase enemyComponent = enemyGO.AddComponent<EnemyBase>();

        enemyGO.transform.localScale = new Vector3(2.116564f, 2.116564f, 2.116564f);
        
        enemyComponent.mEXP = exp;
        enemyComponent.mPoints = points;
        enemyComponent.mHealth = health;
        enemyComponent.mMaxHealth = health;
        enemyComponent.mQueueStates = AIStates;
        enemyComponent.mSmallExplosionPrefab = smallExplosion;
        enemyComponent.mBigExplosionPrefab = largeExplosion;

        enemyGO.name = enemyName;
        enemyGO.tag = "ENEMY";

        SpriteRenderer spRenderer = enemyGO.AddComponent<SpriteRenderer>();
        spRenderer.sprite = sprite;
        spRenderer.sortingLayerName = "Enemy";

        Rigidbody2D rb2d = enemyGO.AddComponent<Rigidbody2D>();
        rb2d.bodyType = RigidbodyType2D.Dynamic;
        rb2d.simulated = true;
        rb2d.useAutoMass = false;
        rb2d.mass = 1;
        rb2d.angularDrag = 0.05f;
        rb2d.gravityScale = 1;
        rb2d.collisionDetectionMode = CollisionDetectionMode2D.Discrete;
        rb2d.sleepMode = RigidbodySleepMode2D.StartAwake;
        rb2d.interpolation = RigidbodyInterpolation2D.None;

        rb2d.constraints = RigidbodyConstraints2D.FreezeAll;

        BoxCollider2D bc2d = enemyGO.AddComponent<BoxCollider2D>();
        bc2d.isTrigger = true;
        bc2d.usedByEffector = false;

    }

    void OnWizardUpdate()
    {
        helpString = "Enter Enemy Details";
    }
}
