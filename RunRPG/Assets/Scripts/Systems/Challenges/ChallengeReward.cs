using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeReward : MonoBehaviour {

    // Use this for initialization
    private int mCoins = 0;
    private int mPoints = 0;

    public void SetPointAmount(int points)
    {
        mPoints = points;
    }
    public int GetPointAmount()
    {
        return mPoints;
    }
    public void SetCoinAmount(int coins)
    {
        mCoins = coins;
    }
    public int GetCoinAmount()
    {
        return mCoins;
    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
