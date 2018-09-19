using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class Shop {
    public UpgradeShop shop;
    public int currentNo;
    public int nextNo;
    public int currentCost;
    public void Start()
    {
        currentCost = shop.StartCost + (shop.CurrentRank * shop.CostPerRank);
        nextNo = currentNo + shop.RankUpMagnitude;
    }
    public void Update()
    {
        currentCost = shop.StartCost + (shop.CurrentRank * shop.CostPerRank);
        nextNo = currentNo + shop.RankUpMagnitude;
    }
    public bool upgrade()
    {
        if (shop.CurrentRank <= shop.MaxRank)
        {
            shop.CurrentRank++;
            currentCost = shop.StartCost + (shop.CurrentRank * shop.CostPerRank);
            currentNo = nextNo;
            nextNo = currentNo + shop.RankUpMagnitude;
            return true;
        }
        return false;
    }
}
