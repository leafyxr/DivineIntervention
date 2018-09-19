using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData { 
    public Stats PlayerStats;
    public int Gold=0;
    public int Progression = 0;
    public int ArmourRank = 0;
    public int WeaponRank = 0;
    public int MagicRank = 0;
    public int ManaRank = 0;

    public PlayerData()
    {
       
    }
    public PlayerData(Stats stats, int gold, int progression)
    {
        PlayerStats = stats;
        Gold = gold;
        Progression = progression;
    }
}
