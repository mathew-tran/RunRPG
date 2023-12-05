using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public enum State
    {
        PRE_GAME,
        IN_GAME,
        END_GAME_LOSE,
        END_GAME_WIN,
        MAIN_MENU
    }
    public State mState;

    public Image[] mHealthSprites;

    [Header("Sliders")]
    public Slider mEnergySlider;
    public Slider mProgressSlider;
    public Slider mExpSlider;

    [Header("Text")]
    public Text mCountDownText;
    public Text mLevelText;
    public Text mPointsText;

    public bool mCanUpdate;

    public Image mEnergyFill;

    [Header("HealthColor")]
    public Color mHealthInUseColor;
    public Color mHealthNoUseColor;

    [Header("EnergyColor")]
    public Color mLowEnergyColor;
    public Color mNormalEnergyColor;
    public Color mShotEnergyColor;

    [Header("References")]
    private Player mPlayerReference;
    private Leveling mPlayerLevelingComponent;
    private TrackManager mTrackReference;

    [Header("StateObjects")]
    public Transform[] mLoseStateObjects;
    public Transform[] mWinStateObjects;
	// Use this for initialization
	void Awake () {
        mLoseStateObjects = GameObject.Find("LoseStateObjects").GetComponentsInChildren<Transform>(true);
        mWinStateObjects = GameObject.Find("WinStateObjects").GetComponentsInChildren<Transform>(true);

        mHealthSprites = GameObject.Find("Health").GetComponentsInChildren<Image>();
        mEnergyFill = GameObject.Find("EnergyFill").GetComponent<Image>();
        mNormalEnergyColor = mEnergyFill.color;
        mCanUpdate = true;
        mCountDownText = GameObject.Find("CountDownText").GetComponent<Text>();
        mLevelText = GameObject.Find("LevelText").GetComponent<Text>();
        mPointsText = GameObject.Find("PointsText").GetComponent<Text>();

        mEnergySlider = GameObject.Find("Energy").GetComponent<Slider>();
        mPlayerReference = ReferenceHelper.GetPlayer();
        mPlayerLevelingComponent = mPlayerReference.GetLevelingComponent();
        mTrackReference = ReferenceHelper.GetTrackManager();
        mProgressSlider = GameObject.Find("TrackProgress").GetComponent<Slider>();
        mExpSlider = GameObject.Find("EXPProgress").GetComponent<Slider>();
    }

    void ResetUI()
    {
        mCountDownText.text = "";
        // Turn off ALL UI components here.
    }

    void ShowCountDown()
    {
        mCountDownText.text = (ReferenceHelper.GetGameManager().GetCountDownTime()+1).ToString();
    }

    public void ShowPlayerHealth()
    {
        int currentHealth = mPlayerReference.GetCurrentHealth();

        int count = 0;

        foreach(Image img in mHealthSprites)
        {
            if(count < currentHealth)
            {
                img.color = mHealthInUseColor;
            }
            else
            {
                img.color = mHealthNoUseColor;
            }
            count++; 
        }
    }
    void ShowPreGameUI()
    {
        ShowCountDown();
    }
    void ShowInGameUI()
    {
        ShowPlayerHealth();

        mEnergySlider.value = mPlayerReference.GetCurrentEnergy() / mPlayerReference.GetMaxEnergy();
        if(!mPlayerReference.GetWeapon().CanShoot())
        {
            mEnergyFill.color = mShotEnergyColor;
        }
        else if(mPlayerReference.GetCurrentEnergy() >= mPlayerReference.GetShootCost())
        {
            mEnergyFill.color = mNormalEnergyColor;
        }
        else
        {
            mEnergyFill.color = mLowEnergyColor;
        }

        mProgressSlider.value = mTrackReference.GetCurrentProgress() / mTrackReference.GetMaxProgress();
        mExpSlider.value = mPlayerLevelingComponent.GetCurrentExperience() / mPlayerLevelingComponent.GetMaxExperience();
        mLevelText.text = "Lv" + mPlayerLevelingComponent.GetLevel().ToString();
        mPointsText.text = ReferenceHelper.GetPointManager().GetPoints().ToString();
    }
    void ShowEndGameLoseUI()
    {
        foreach(Transform obj in mLoseStateObjects)
        {
            obj.gameObject.SetActive(true);
        }
    }
    void ShowEndGameWinUI()
    {
        foreach (Transform obj in mWinStateObjects)
        {
            obj.gameObject.SetActive(true);
        }
    }
    void ShowMainMenuUI()
    {

    }
	public void SetUIState(State newState)
    {
        ResetUI();
        mState = newState;
       
    }
    public void SetUIUpdate(bool value)
    {
        mCanUpdate = value;
    }
	// Update is called once per frame
	void Update ()
    {

        switch (mState)
        {
            case State.PRE_GAME:
                ShowPreGameUI();
                break;

            case State.END_GAME_WIN:
                ShowEndGameWinUI();
                break;

            case State.END_GAME_LOSE:
                ShowEndGameLoseUI();
                break;

            case State.IN_GAME:
                ShowInGameUI();
                break;

            case State.MAIN_MENU:
                ShowMainMenuUI();
                break;

            default:
                break;
        }
        
    }
}
