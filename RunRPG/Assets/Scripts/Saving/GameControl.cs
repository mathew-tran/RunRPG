using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;
using System;

// Base Code taken from unity tutorial:
// https://unity3d.com/learn/tutorials/topics/scripting/persistence-saving-and-loading-data

public class GameControl : MonoBehaviour {

    private int mCoins = 0;
    private int mLevel = 0;
    private float mPointsTowardsLevel = 0.0f;
    private float mMaxPointsTowardsLevel = 1000.0f;
    public static GameControl GameControlMaster;
    public bool mIsLoaded = false;
    

    void Start()
    {
        
        if(!GameControlMaster)
        {
            GameControlMaster = this;
        }
        if(GameControlMaster != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        mIsLoaded = false;
    }

    public int GetCoins()
    {
        return mCoins;
    }
    public int GetLevel()
    {
        return mLevel;
    }
    public float GetPointsTowardsLevel()
    {
        return mPointsTowardsLevel;
    }
    public float GetMaxPointsTowardsLevel()
    {
        return mMaxPointsTowardsLevel;
    }
    public void SetCoins(int coins)
    {
        mCoins = coins;
    }
    public void SetAllLevelStats()
    {
        SetLevel(ReferenceHelper.GetShopLevelManager().GetLevel());
        SetPointsTowardsLevel(ReferenceHelper.GetShopLevelManager().GetPointsTowardsLevel());
        SetPointsTowardsMaxLevel(ReferenceHelper.GetShopLevelManager().GetPointsTowardMaxLevel());

    }
    public void SetLevel(int level)
    {
        mLevel = level;
    }
    public void SetPointsTowardsLevel(float points)
    {
        mPointsTowardsLevel = points;
    }
    public void SetPointsTowardsMaxLevel(float points)
    {
        mMaxPointsTowardsLevel = points;
    }
    private void Save()
    {        
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerinfo.dat");
        FileData data = new FileData();

        data.coins = mCoins;
        data.level = mLevel;

        data.MaxPointsTowardsLevel = mMaxPointsTowardsLevel;
        data.PointsTowardsLevel = mPointsTowardsLevel;

        bf.Serialize(file, data);
        file.Close();

    }
    public void SaveAllFiles()
    {

        SetCoins(ReferenceHelper.GetCoinManager().GetCoins());
        SetAllLevelStats();
        Save();
    }
    public bool Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerinfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerinfo.dat", FileMode.Open);

            FileData data = (FileData)bf.Deserialize(file);
            file.Close();

            mCoins = data.coins;
            mLevel = data.level;
            mMaxPointsTowardsLevel = data.MaxPointsTowardsLevel;
            mPointsTowardsLevel = data.PointsTowardsLevel;

            mIsLoaded = true;
            return true;

        }
        SaveAllFiles();
        return false;

    }
    public void Delete()
    {
        Debug.Log("DELETE");
        if(File.Exists(Application.persistentDataPath + "/playerinfo.dat"))
        {
            File.Delete(Application.persistentDataPath + "/playerinfo.dat");
        }

        ReferenceHelper.GetShopLevelManager().Reset();
        ReferenceHelper.GetCoinManager().ResetCoins();

        SaveAllFiles();
        Load();
    }
}
[Serializable]
class FileData
{
    public int coins;
    public int level;
    public float PointsTowardsLevel = 0.0f;
    public float MaxPointsTowardsLevel = 1000.0f;
}