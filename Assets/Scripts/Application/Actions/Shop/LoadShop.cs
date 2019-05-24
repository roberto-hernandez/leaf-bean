using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadShop : MonoBehaviour {
    public Canvas canvas;
    public GameObject content;
    public GameObject MenuItemPrefab;

    // Use this for initialization
    void Start () {
        canvas.enabled = false;
        
        var shop = ShopFactory.Create();
        foreach (var item in shop.GetItems())
        {
            AddShopItem(item);
        }

        canvas.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void AddShopItem(ShopItem item)
    {
        var menuItemGO = Instantiate(MenuItemPrefab, content.transform);
        menuItemGO.GetComponentInChildren<Transform>().Find("MenuItemName").gameObject.GetComponent<Text>().text = item.Name;
        menuItemGO.GetComponentInChildren<Transform>().Find("MenuItemCost").gameObject.GetComponent<Text>().text = item.Cost.ToString();
    }
}

class ShopFactory
{
    public static Shop Create()
    {
        var shop = new Shop();
        shop.AddItem(new ShopItem() { Name = "Turret", Cost = 100 });
        shop.AddItem(new ShopItem() { Name = "Missile Launcher", Cost = 300 });
        // shop.AddItem(new ShopItem() { Name = "Health", Cost = "10%" });
        return shop;
    }
}

class Shop
{
    public void AddItem(ShopItem item)
    {
        Items.Add(item);
    }

    public IEnumerable<ShopItem> GetItems()
    {
        return Items;
    }

    public Shop()
    {
        this.Items = new List<ShopItem>();
    }

    private IList<ShopItem> Items { get; set; }
}

class ShopItem
{
    public string Name { get; set; }
    public int Cost { get; set; }
}
