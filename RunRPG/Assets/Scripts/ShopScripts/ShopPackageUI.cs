using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPackageUI : MonoBehaviour {

    // Use this for initialization
    public Text mShopPackageText;
    
	void Start () {
        mShopPackageText = GameObject.Find("ShopPackageText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        mShopPackageText.text = ShopPackage.ShopPackageMaster.GetPackageString();
	}
}
