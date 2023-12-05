using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelOverworldButton : MonoBehaviour {

	// Use this for initialization
    public enum BUTTON_STATUS
    {
        TODO,
        COMPLETE,
        BLOCKED
    }

    public BUTTON_STATUS mStatus;
    public Button mButton;
    public int mLevel;

    public void HandleClick()
    {
        Debug.Log("Go to level " + mLevel);
        LevelData.LevelDataMaster.mLevel = mLevel;
        SceneManager.LoadScene("Level");
    }
    public void Setup(BUTTON_STATUS status, int level)
    {
        mStatus = status;
        mLevel = level;
        
        ColorBlock col = GetComponent<Button>().colors;
        switch (mStatus)
        {
            case BUTTON_STATUS.TODO:
                
                col.normalColor = Color.yellow;
                col.highlightedColor = Color.yellow;
                col.pressedColor = Color.yellow + new Color(0, 0, 0, -.5f);
                col.disabledColor = Color.yellow;
                break;

            case BUTTON_STATUS.COMPLETE:
                col.normalColor = Color.green;
                col.highlightedColor = Color.green;
                col.pressedColor = Color.green + new Color(0, 0, 0, -.5f);
                col.disabledColor = Color.green;
                break;

            case BUTTON_STATUS.BLOCKED:
                col.normalColor = Color.gray;
                col.highlightedColor = Color.gray;
                col.pressedColor = Color.gray;
                col.disabledColor = Color.gray;
                break;
        }
        GetComponent<Button>().colors = col;

        if(mStatus != BUTTON_STATUS.BLOCKED)
        {
            mButton.onClick.AddListener(HandleClick);
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
