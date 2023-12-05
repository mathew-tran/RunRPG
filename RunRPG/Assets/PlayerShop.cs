using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShop : Shop {
    // Use this for initialization
    public bool mIsIntiialized = false;
    public MainCoinUIText mText;
   public override void Start()
   {        
        mIsIntiialized = false;
        base.Start();      

    }
    public override void AddButtons()
    {

        mItemList.Sort(new ItemPriceComparer());
        for (int i = 0; i < mItemList.Count; ++i)
        {
            Item item = mItemList[i];
            GameObject newButton = buttonObjectPool.GetObject();
            newButton.transform.SetParent(mContentPanel);

            SampleButton sampleButton = newButton.GetComponent<SampleButton>();
            sampleButton.Setup(item, this);
        }
    }
    public void Update()
    {
        if(!mIsIntiialized)
        {
            if(GameControl.GameControlMaster != null)
            {
                GameControl.GameControlMaster.Load();
                mIsIntiialized = true;
                mCoins = ReferenceHelper.GetCoinManager().GetCoins();

            }
        }
    }
    public override void RefreshDisplay()
    {        
        base.RefreshDisplay();
        mText.SetUpdateFlag();
        ShopPackage package = GameObject.FindWithTag("PACKAGE").GetComponent<ShopPackage>();
        package.UpdatePackage();
    }

}
