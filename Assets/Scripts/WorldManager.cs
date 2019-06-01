using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldManager : MonoBehaviour
{
    private static WorldManager instance;
    private int level;
    private Text moneyCounter;
    private IList<GameObject> enemies;
    public bool inBattleMode;
    public GameObject itemInstance;
    public GameObject enemyPrefab;

    // Use this for initialization
    void Awake()
    {
        instance = instance ?? this;
        enemies = new List<GameObject>();
        level = 1;
    }

    void Start()
    {
        moneyCounter = GameObject.Find("MoneyText").GetComponent<Text>();
    }

    public static WorldManager GetInstance()
    {
        return instance;
    }

    public void AddEnemy()
    {
        for(var i = 0; i < level; i++)
        {
            //var enemy = Instantiate(enemyPrefab);
            enemies.Add(Instantiate(enemyPrefab));
        }
        level++;
    }

    public void DestroyEnemies()
    {
        foreach(var enemy in enemies)
        {
            Destroy(enemy);
        }
        enemies.Clear();
    }

    public void IncreaseMoney()
    {
        var money = int.Parse(moneyCounter.text);
        moneyCounter.text = (money + 10).ToString();

    }

    public int GetMoney()
    {
        return int.Parse(moneyCounter.text);
    }

    public void SubtractMoney(int money)
    {
        moneyCounter.text = (int.Parse(moneyCounter.text) - money).ToString();
    }
}
