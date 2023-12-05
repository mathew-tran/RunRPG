using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour {

    public int mCoins = 0;
    public static CoinManager MasterCoinManager;

	// Use this for initialization
	public void Start () {
        if (!MasterCoinManager)
        {
            MasterCoinManager = this;
        }
        if (MasterCoinManager != this)
        {
            Destroy(gameObject);
        }
        if (ReferenceHelper.GetGameControl().Load())
        {
            mCoins = ReferenceHelper.GetGameControl().GetCoins();
        }
	}
	
	// Update is called once per frame
	public void AddCoins(int coins)
    {
        mCoins += coins;
    }
    public void RemoveCoins(int coins)
    {
        mCoins -= coins;
    }
    public void ResetCoins()
    {
        mCoins = 0;
    }
    public int GetCoins()
    {
        return mCoins;
    }
}
