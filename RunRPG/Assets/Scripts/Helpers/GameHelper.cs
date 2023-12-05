using UnityEngine;
using System.Collections;

public static class GameHelper {

	public static bool AreEnemiesOnScreen()
    {
        EnemyBase[] movers = GameObject.FindObjectsOfType<EnemyBase>();
        return movers.Length >= 1;
    }
    public static int GetEnemyAmount()
    {
        EnemyBase[] movers = GameObject.FindObjectsOfType<EnemyBase>();
        return movers.Length;
    }
    public static bool IsTrackRunning()
    {
        return ReferenceHelper.GetTrackManager().IsTrackRunning();
    }
    public static void AddPlayerExperience(float exp)
    {
        ReferenceHelper.GetPlayer().GetLevelingComponent().AddExperience(exp);
    }
    public static void AddPoints(int points)
    {
        ReferenceHelper.GetPointManager().AddPoints(points);
    }
    public static bool IsPlayerAlive()
    {
        return ReferenceHelper.GetPlayer().IsAlive();
    }
    public static bool IsGamePlaying()
    {
        return ReferenceHelper.GetGameManager().GetState() == GameManager.STATE.INGAME;
    }
    public static void ActivateOnGroundEvent()
    {
        ReferenceHelper.GetOnGroundEvent().Run();
    }
    public static void ActivateOffGroundEvent()
    {
        ReferenceHelper.GetOffGroundEvent().Run();
    }
    public static void ActivateOnHitEvent()
    {
        ReferenceHelper.GetOnHitEvent().Run();
    }
    public static void ActivateOnKillEvent()
    {
        ReferenceHelper.GetOnKillEvent().Run();
    }
    public static void ActivateOnShotEvent()
    {
        ReferenceHelper.GetOnShotEvent().Run();
    }
    public static void ActivateOnHurtEvent()
    {
        ReferenceHelper.GetOnHurtEvent().Run();
    }
    public static void ActivateOnJumpEvent()
    {
        ReferenceHelper.GetOnJumpAttackEvent().Run();
    }
    public static void AddMessage(string message)
    {
        ReferenceHelper.GetMessageBoxSystem().addMessage(message);
    }
    public static void GenerateName()
    {
        ReferenceHelper.GetNameGenerator().GenerateName();
    }
    public static string GetName()
    {
        return ReferenceHelper.GetNameGenerator().GetName();
    }
    public static bool IsCalculating()
    {
        return ReferenceHelper.GetPointManager().IsCalculating() || ReferenceHelper.GetPlayer().GetLevelingComponent().IsCalculating();
    }
}
