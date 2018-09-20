using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blacksmith : MonoBehaviour {
    [SerializeField]
    private DataManager dataManager;
    [SerializeField]
    private Shop Weapons;
    public Text CurrentDamageText;
    public Text NextDamageText;
    public Text WeaponCost;
    [SerializeField]
    private Shop Armour;
    public Text CurrentArmourText;
    public Text NextArmourText;
    public Text ArmourCost;
    [SerializeField]
    private Image[] RankIconWeapons;
    [SerializeField]
    private Image[] RankIconArmour;
    [SerializeField]
    private Sprite FullSprite;
    [SerializeField]
    private Sprite EmptySprite;

    void Start () {
        Weapons.shop.CurrentRank = dataManager.data.WeaponRank;
        Armour.shop.CurrentRank = dataManager.data.ArmourRank;
        updateMeter(RankIconArmour, Armour.shop.CurrentRank);
        updateMeter(RankIconWeapons, Weapons.shop.CurrentRank);
        Weapons.Start();
        Armour.Start();
        Weapons.currentNo = dataManager.data.PlayerStats.MeleePower;
        Armour.currentNo = dataManager.data.PlayerStats.Resistance;
    }
	
	// Update is called once per frame
	void Update () {
        //Weapons
        Weapons.Update();
        Weapons.currentNo = dataManager.data.PlayerStats.MeleePower;
        CurrentDamageText.text = Weapons.currentNo.ToString();
        NextDamageText.text = Weapons.nextNo.ToString();
        WeaponCost.text = Weapons.currentCost.ToString() + "g";
        Weapons.shop.CurrentRank = dataManager.data.WeaponRank;
        updateMeter(RankIconWeapons, Weapons.shop.CurrentRank);
        //Armour
        Armour.Update();
        Armour.currentNo = dataManager.data.PlayerStats.Resistance;
        CurrentArmourText.text = Armour.currentNo.ToString() + "%";
        NextArmourText.text = Armour.nextNo.ToString() + "%";
        ArmourCost.text = Armour.currentCost.ToString() + "g";
        Armour.shop.CurrentRank = dataManager.data.ArmourRank;
        updateMeter(RankIconArmour, Armour.shop.CurrentRank);
    }

    public void ArmourUpgrade()
    {
        if (dataManager.data.Gold >= Armour.currentCost)
        {
            dataManager.data.Gold -= Armour.currentCost;
            if (Armour.upgrade())
            {
                dataManager.data.PlayerStats.Resistance = Armour.currentNo;
                dataManager.data.ArmourRank = Armour.shop.CurrentRank;
            }
            else
            {
                dataManager.data.Gold += Armour.currentCost;
            }
            dataManager.dataSave();
        }
        updateMeter(RankIconArmour, Armour.shop.CurrentRank);
    }

    public void WeaponUpgrade()
    {
        if (dataManager.data.Gold >= Weapons.currentCost)
        {
            dataManager.data.Gold -= Weapons.currentCost;
            if (Weapons.upgrade())
            {
                dataManager.data.PlayerStats.MeleePower = Weapons.currentNo;
                dataManager.data.WeaponRank = Weapons.shop.CurrentRank;
            }
            else
            {
                dataManager.data.Gold += Weapons.currentCost;
            }
            dataManager.dataSave();
        }
        updateMeter(RankIconWeapons, Weapons.shop.CurrentRank);
    }
    private void updateMeter(Image[] Meter, int rank)
    {
        for(int i = 0; i<rank; i++)
        {
            Meter[i].sprite = FullSprite;
        }
        for(int i = rank; i < Meter.Length; i++)
        {
            Meter[i].sprite = EmptySprite;
        }
    }

}
