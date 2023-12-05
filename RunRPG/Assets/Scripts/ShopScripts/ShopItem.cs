using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour {

    public GameObject mItem;
    public int mPrice = 100;
    public bool mIsPurchasable = true;
	// Use this for initialization

    void Start()
    {
        if(ShopPackage.ShopPackageMaster)
            mIsPurchasable = ShopPackage.ShopPackageMaster.DoesObjectExist(this.gameObject);
    }

    public bool Purchase()
    {
        if (mIsPurchasable)
        {
            //if (ReferenceHelper.GetGameControl().GetCoins() >= mPrice)
            //{
            //    mIsPurchasable = false;
            //    ShopPackage.ShopPackageMaster.AddStoreObject(mItem);
               
            //    GameControl control = ReferenceHelper.GetGameControl();
            //    int coins = control.GetCoins();
            //    control.SetCoins(coins - mPrice);
            //    ReferenceHelper.GetCoinManager().RemoveCoins(mPrice);
            //    GameObject.Find("CoinText").GetComponent<MainCoinUIText>().SetUpdateFlag();
            //    control.Save();
                
            //    return true;
            //}
        }
        
        return false;
    }

	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A))
        {
            Purchase();
        }
	}
}
