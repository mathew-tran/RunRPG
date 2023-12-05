using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorePurchase : MonoBehaviour {

	public void Purchase()
    {
        int coinAmount = 0;
        foreach (Item itm in GameObject.FindGameObjectWithTag("SHOP").GetComponent<PlayerShop>().mItemList)
        {
            coinAmount += itm.mPrice;
        }
        ReferenceHelper.GetCoinManager().RemoveCoins(coinAmount);
        ReferenceHelper.GetGameControl().SaveAllFiles();
        gameObject.AddComponent<LoadQuickPlay>();
        gameObject.GetComponent<LoadQuickPlay>().Load();


    }
}
