using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class UpgradeShop {
    public int StartRank = 0;
    public int CurrentRank = 0;
    public int MaxRank = 5;
    public int StartCost = 500;
    public int CostPerRank = 500;
    public int RankUpMagnitude = 10;

}
