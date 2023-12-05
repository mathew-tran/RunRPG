using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public SimpleObjectPool mButtonObjectPool;
    public Transform mContentPanel;
    private int mMaxLevel = 20;
    private int mCurrentLevel = 3;

	public void Start()
    {
        RefreshDisplay();
    }
    public void RefreshDisplay()
    {
        RemoveButtons();
        AddButtons();
    }
    private void AddButtons()
    {
        for(int i =0; i < mMaxLevel; ++i)
        {
            GameObject newButton = mButtonObjectPool.GetObject();
            newButton.transform.SetParent(mContentPanel);

            LevelOverworldButton sampleButton = newButton.GetComponent<LevelOverworldButton>();
            LevelOverworldButton.BUTTON_STATUS status;
            if (mCurrentLevel > i)
            {
                status = LevelOverworldButton.BUTTON_STATUS.COMPLETE;
            }
            else if(mCurrentLevel == i)
            {
                status = LevelOverworldButton.BUTTON_STATUS.TODO;
            }
            else
            {
                status = LevelOverworldButton.BUTTON_STATUS.BLOCKED;
            }
            sampleButton.Setup(status, i);
        }
    }
    public void RemoveButtons()
    {
        while (mContentPanel.childCount > 0)
        {
            GameObject toRemove = transform.GetChild(0).gameObject;
            mButtonObjectPool.ReturnObject(toRemove);
        }
    }
}
