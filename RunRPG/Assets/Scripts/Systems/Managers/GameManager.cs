using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    // Use this for initialization
    public enum STATE
    {
        WIN, // Player has won
        INGAME, // Game is being played
        OUTGAME, // Not In Game
        LOSE // Player has lost
    }
    public float mStartTime = 3.0f;
    public TrackManager TrackReference;
    public BlockSpawner SpawnReference;
    public STATE mState;
    public int GetCountDownTime()
    {
        return (int)mStartTime;
    }

	void Start ()
    {
        Screen.SetResolution(1024, 768, true);
        TrackReference = ReferenceHelper.GetTrackManager();
        SpawnReference = ReferenceHelper.GetBlockSpawner();
        SpawnReference.SetSpawnerActivity(true);
        SpawnReference.ForceBlockSpawn(ReferenceHelper.GetBlockRepo().Block);
        StartCoroutine("Starting");
        GameHelper.GenerateName();
        mState = STATE.OUTGAME;
        

    }
    public STATE GetState()
    {
        return mState;
    }
    IEnumerator Starting()
    {
        ReferenceHelper.GetPlayer().EnableControls(false);
        ReferenceHelper.GetUIManager().SetUIState(UIManager.State.PRE_GAME);
        while (mStartTime > 0.0f)
        {
            mStartTime -= Time.deltaTime;
            yield return null;
        }
        ReferenceHelper.GetPlayer().SetKinematic(false);
        ReferenceHelper.GetUIManager().SetUIUpdate(false);
        SpawnReference.RemoveForceBlockSpawn();
        ReferenceHelper.GetPlayer().EnableControls(true);
        ReferenceHelper.GetUIManager().SetUIState(UIManager.State.IN_GAME);
        TrackReference.ContinueProgress();
        GameHelper.AddMessage("Welcome, " + GameHelper.GetName() + "!");
        ReferenceHelper.GetPlayer().GetSkillsCache().ShowSkills();
        mState = STATE.INGAME;
    }
    IEnumerator Ending(STATE state)
    {
        GameObject.FindGameObjectWithTag("PACKAGE").GetComponent<ShopPackage>().SetDifficulty();

        if (state == STATE.WIN)
        {

            ChallengeReward[] gos = GetComponentsInChildren<ChallengeReward>();
            foreach (ChallengeReward reward in gos)
            {
                ReferenceHelper.GetCoinManager().AddCoins(reward.GetCoinAmount());
                ReferenceHelper.GetPointManager().AddPoints(reward.GetPointAmount());
                GameHelper.AddMessage("Challenge Complete!");
                GameHelper.AddMessage(GameHelper.GetName() + " gained (" + reward.GetCoinAmount() + ") coins for completion");
                GameHelper.AddMessage(GameHelper.GetName() + " gained (" + reward.GetPointAmount() + ") points for completion");
            }
        }
      
        float mTime = 2.0f;
        while (mTime > 0.0f)
        {
            mTime -= Time.deltaTime;
            yield return null;
        }
        mState = state;

        int coinAmount = ReferenceHelper.GetPointManager().GetPoints() / 1000;
        GameHelper.AddMessage(GameHelper.GetName() + " gained (" + coinAmount + ") coins");

        ReferenceHelper.GetCoinManager().AddCoins(coinAmount);
        ReferenceHelper.GetShopLevelManager().AddLevelPoints(ReferenceHelper.GetPointManager().GetPoints());

        GameHelper.AddMessage(GameHelper.GetName() + " has (" + ReferenceHelper.GetCoinManager().GetCoins() + ") total coins!");
        ReferenceHelper.GetGameControl().SaveAllFiles();
        if (state == STATE.WIN)
        {
            ReferenceHelper.GetUIManager().SetUIState(UIManager.State.END_GAME_WIN);
        }
        else
        {
            ReferenceHelper.GetUIManager().SetUIState(UIManager.State.END_GAME_LOSE);
        }
    }
    public void EndGame(STATE state)
    {
        ReferenceHelper.GetPlayer().AllowPlayerControl(false);
        ReferenceHelper.GetBlockSpawner().SetSpawnerActivity(false);
        Destroy(ReferenceHelper.GetBlockSpawner());
        TrackReference.StopProgress();
        StartCoroutine("Ending",state);
      

    }
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}

}
