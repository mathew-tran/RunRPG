using UnityEngine;
using System.Collections;

public static class ReferenceHelper {

    public static BlockSpawner GetBlockSpawner()
    {
        return GameObject.Find("BlockSpawner").GetComponent<BlockSpawner>();
    }
    public static EnemySpawner GetEnemySpawner()
    {
        return GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
    }
    public static GameManager GetGameManager()
    {
        return GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public static UIManager GetUIManager()
    {
        return GameObject.Find("UIManager").GetComponent<UIManager>();
    }
    public static Player GetPlayer()
    {
        return GameObject.Find("Player").GetComponent<Player>();
    }
    public static TrackManager GetTrackManager()
    {
        return GameObject.Find("TrackManager").GetComponent<TrackManager>();
    }
    public static BlockRepo GetBlockRepo()
    {
        return GameObject.Find("BlockRepo").GetComponent<BlockRepo>();
    }
    public static PointManager GetPointManager()
    {
        return GameObject.Find("PointsManager").GetComponent<PointManager>();
    }
    public static GameEvent GetOnGroundEvent()
    {
        return GameObject.Find("OnGround").GetComponent<GameEvent>();
    }
    public static GameEvent GetOffGroundEvent()
    {
        return GameObject.Find("OffGround").GetComponent<GameEvent>();
    }
    public static GameEvent GetOnHitEvent()
    {
        return GameObject.Find("OnHit").GetComponent<GameEvent>();
    }
    public static GameEvent GetOnKillEvent()
    {
        return GameObject.Find("OnKill").GetComponent<GameEvent>();
    }
    public static GameEvent GetOnShotEvent()
    {
        return GameObject.Find("OnShot").GetComponent<GameEvent>();
    }
    public static GameEvent GetOnHurtEvent()
    {
        return GameObject.Find("OnHurt").GetComponent<GameEvent>();
    }
    public static GameEvent GetOnJumpAttackEvent()
    {
        return GameObject.Find("OnJumpAttack").GetComponent<GameEvent>();
    }
    public static GameControl GetGameControl()
    {
        return GameObject.Find("PersistenceModule").GetComponent<GameControl>();
    }
    public static CoinManager GetCoinManager()
    {
        return GameObject.Find("CoinManager").GetComponent<CoinManager>();
    }
    public static ShopLevelManager GetShopLevelManager()
    {
        return GameObject.Find("ShopLevelManager").GetComponent<ShopLevelManager>();

    }
    public static MessageBoxSystem GetMessageBoxSystem()
    {
        return GameObject.Find("MessageBoxSystem").GetComponent<MessageBoxSystem>();
    }
    public static NameGenerator GetNameGenerator()
    {
        return GameObject.Find("NameGenerator").GetComponent<NameGenerator>();
    }
}
