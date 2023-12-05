using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[System.Serializable]
public class Item
{
    public Sprite mIcon;
    public int mPrice;
    public GameObject mSkill;
}

public class ItemPriceComparer : Comparer<Item>
{
    public override int Compare(Item x, Item y)
    {
        if(x.mPrice == y.mPrice)
        {
            return 0;
        }
        if(x.mPrice > y.mPrice)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }
}
public class Shop : MonoBehaviour {

    // Use this for initialization
    public List<Item> mItemList;
    public Transform mContentPanel;
    public Shop mOtherShop;
    public SimpleObjectPool buttonObjectPool;
    public int mCoins = 10;
    private int mLevel = 3;
	public virtual void Start ()
    {
        mLevel = GameControl.GameControlMaster.GetLevel();
        if(mLevel < mItemList.Count)
        {
            mItemList.RemoveRange(mLevel, (mItemList.Count - mLevel));
        }
        RefreshDisplay();
        
	}

    public virtual void RefreshDisplay()
    {
     
        RemoveButtons();
        AddButtons();
    }

    public virtual void AddButtons()
    {
        
        mItemList.Sort(new ItemPriceComparer());

        int price = 0;
        foreach (Item itm in mOtherShop.mItemList)
        {
            price -= itm.mPrice;
        }
        price += ReferenceHelper.GetCoinManager().GetCoins();

        for(int i = 0; i < mItemList.Count; ++i)
        {
            Item item = mItemList[i];
            GameObject newButton = buttonObjectPool.GetObject();
            newButton.transform.SetParent(mContentPanel);

            SampleButton sampleButton = newButton.GetComponent<SampleButton>();
            sampleButton.Setup(item, this);


            if (mItemList[i].mPrice > price)
            {
                sampleButton.mPriceLabel.color = Color.red;
            }
            else
            {
                sampleButton.mPriceLabel.color = Color.black;
            }
            
        }
    }
    public void TryTransferItemToOtherShop(Item item)
    {
        
        if (mOtherShop.mCoins >= item.mPrice)
        {
            mCoins += item.mPrice;
            mOtherShop.mCoins -= item.mPrice;
            AddItem(item, mOtherShop);
            RemoveItem(item, this);

            RefreshDisplay();
            mOtherShop.RefreshDisplay();
        }
    }
    public void AddItem(Item itemToAdd, Shop shopList)
    {
        shopList.mItemList.Add(itemToAdd);
    }

    private void RemoveButtons()
    {
        while(mContentPanel.childCount > 0)
        {
            GameObject toRemove = transform.GetChild(0).gameObject;
            buttonObjectPool.ReturnObject(toRemove);
        }
    }
    public void RemoveItem(Item itemToRemove, Shop shopList)
    {
        for(int i = shopList.mItemList.Count - 1; i >= 0; i--)
        {
            if(shopList.mItemList[i] == itemToRemove)
            {
                shopList.mItemList.RemoveAt(i);
            }
        }
    }

}
