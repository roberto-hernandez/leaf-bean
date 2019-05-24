using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuyShopItem : MonoBehaviour {
    public GameObject itemPrefab;

    // Use this for initialization
    void Start () {
        var button = gameObject.GetComponentInChildren<Transform>().Find("MenuItemBuyButton").gameObject.GetComponent<Button>();
        button.onClick.AddListener(BuyItemAction);
    }

    void BuyItemAction()
    {
        var canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        canvas.enabled = false;

        var itemName = gameObject.GetComponentInChildren<Transform>().Find("MenuItemName").gameObject.GetComponent<Text>().text;
        Instantiate(itemPrefab);
    }
}
