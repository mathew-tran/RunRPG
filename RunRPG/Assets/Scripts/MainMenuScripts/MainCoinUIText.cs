using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCoinUIText : MonoBehaviour {

    // Use this for initialization
    bool mHasUpdated = false;
    private Text mText;
    public PlayerShop mPlayerShop;
    public int mShopCoins = 0;
    public void SetUpdateFlag()
    {
        mHasUpdated = false;
    }
	void Start () {
        mText = GameObject.Find("CoinText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	public void Update () {
        if(!mHasUpdated)
		if(ReferenceHelper.GetGameControl().mIsLoaded)
        {
            mHasUpdated = true;
                mShopCoins = 0;
                if (mPlayerShop)
                foreach(Item itm in mPlayerShop.mItemList)
                {
                        mShopCoins += itm.mPrice;
                }
                mShopCoins = ReferenceHelper.GetCoinManager().GetCoins() - mShopCoins;

                mText.text = mShopCoins.ToString()  + " Coins";
        }
	}
}
