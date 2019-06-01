using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuyShopItem : MonoBehaviour {
    public GameObject itemPrefab;
    public Canvas menuCanvasGO;

    // Use this for initialization
    void Start () {
        var button = gameObject.GetComponentInChildren<Transform>().Find("MenuItemBuyButton").gameObject.GetComponent<Button>();
        button.onClick.AddListener(BuyItemAction);
    }

    void BuyItemAction()
    {
        var worldManager = WorldManager.GetInstance();
        if(worldManager.GetMoney() >= int.Parse(gameObject.GetComponentInChildren<Transform>().Find("MenuItemCost").gameObject.GetComponent<Text>().text))
        {
            var canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
            canvas.enabled = false; 

            var itemName = gameObject.GetComponentInChildren<Transform>().Find("MenuItemName").gameObject.GetComponent<Text>().text;
            var itemGo = Instantiate(itemPrefab);
        }
    }
}
