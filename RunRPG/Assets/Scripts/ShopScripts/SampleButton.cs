using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleButton : MonoBehaviour {

    public Button mButton;
    public Text mNameLabel;
    public Text mPriceLabel;
    public Text mDescriptionLabel;
    public Text mLevelLabel;
    public Image mIconImage;
    public GameObject mSkill;

    private Item mItem;
    private Shop mShopList;
    void Start()
    {
        mButton.onClick.AddListener(HandleClick);

    }
    public void Setup(Item item, Shop shopList)
    {
        mItem = item;
        mNameLabel.text = item.mSkill.GetComponent<Skill>().GetSkillName();
        mDescriptionLabel.text = item.mSkill.GetComponent<Skill>().GetSkillDescription();
        mLevelLabel.text = "Unlock at level " + item.mSkill.GetComponent<Skill>().GetLevel().ToString();

        mPriceLabel.text = item.mPrice.ToString();
        mIconImage.sprite = item.mIcon;
        mSkill = item.mSkill;

        mShopList = shopList;

    }
    public void HandleClick()
    {
        mShopList.TryTransferItemToOtherShop(mItem);
    }
}
