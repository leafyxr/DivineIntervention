using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChurchShop : MonoBehaviour {
    [SerializeField]
    private DataManager dataManager;
    [SerializeField]
    private Shop MagicDamage;
    public Text CurrentDamageText;
    public Text NextDamageText;
    public Text MagicCost;
    [SerializeField]
    private Shop Mana;
    public Text CurrentManaText;
    public Text NextManaText;
    public Text ManaCost;
    [SerializeField]
    private Image[] RankIconMagicDam;
    [SerializeField]
    private Image[] RankIconMana;
    [SerializeField]
    private Sprite FullSprite;
    [SerializeField]
    private Sprite EmptySprite;

    void Start()
    {
        MagicDamage.shop.CurrentRank = dataManager.data.MagicRank;
        Mana.shop.CurrentRank = dataManager.data.ManaRank;
        updateMeter(RankIconMana, Mana.shop.CurrentRank);
        updateMeter(RankIconMagicDam, MagicDamage.shop.CurrentRank);
        MagicDamage.Start();
        Mana.Start();
        MagicDamage.currentNo = dataManager.data.PlayerStats.RangedPower;
        Mana.currentNo = dataManager.data.PlayerStats.Magic;
    }

    // Update is called once per frame
    void Update()
    {
        //Weapons
        MagicDamage.Update();
        MagicDamage.currentNo = dataManager.data.PlayerStats.RangedPower;
        CurrentDamageText.text = MagicDamage.currentNo.ToString();
        NextDamageText.text = MagicDamage.nextNo.ToString();
        MagicCost.text = MagicDamage.currentCost.ToString() + "g";
        MagicDamage.shop.CurrentRank = dataManager.data.MagicRank;
        updateMeter(RankIconMagicDam, MagicDamage.shop.CurrentRank);
        //Armour
        Mana.Update();
        Mana.currentNo = dataManager.data.PlayerStats.Magic;
        CurrentManaText.text = Mana.currentNo.ToString();
        NextManaText.text = Mana.nextNo.ToString();
        ManaCost.text = Mana.currentCost.ToString() + "g";
        Mana.shop.CurrentRank = dataManager.data.ManaRank;
        updateMeter(RankIconMana, Mana.shop.CurrentRank);
    }

    public void ManaUpgrade()
    {
        if (dataManager.data.Gold >= Mana.currentCost)
        {
            dataManager.data.Gold -= Mana.currentCost;
            if (Mana.upgrade())
            {
                dataManager.data.PlayerStats.Magic = Mana.currentNo;
                dataManager.data.ManaRank = Mana.shop.CurrentRank;
            }
            else
            {
                dataManager.data.Gold += Mana.currentCost;
            }
            dataManager.dataSave();
        }
        updateMeter(RankIconMana, Mana.shop.CurrentRank);
    }

    public void  MagicUpgrade()
    {
        if (dataManager.data.Gold >= MagicDamage.currentCost)
        {
            dataManager.data.Gold -= MagicDamage.currentCost;
            if (MagicDamage.upgrade())
            {
                dataManager.data.PlayerStats.RangedPower = MagicDamage.currentNo;
                dataManager.data.MagicRank = MagicDamage.shop.CurrentRank;
            }
            else
            {
                dataManager.data.Gold += MagicDamage.currentCost;
            }
            dataManager.dataSave();
        }
        updateMeter(RankIconMagicDam, MagicDamage.shop.CurrentRank);
    }
    private void updateMeter(Image[] Meter, int rank)
    {
        for (int i = 0; i < rank; i++)
        {
            Meter[i].sprite = FullSprite;
        }
        for (int i = rank; i < Meter.Length; i++)
        {
            Meter[i].sprite = EmptySprite;
        }
    }

}
