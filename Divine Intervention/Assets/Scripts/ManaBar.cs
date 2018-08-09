using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour {
    [SerializeField]
    private int maxMana = 100;
    [SerializeField]
    RectTransform manaBar;
    private int currentMana;
    private float BarSize;

	void Start () {
        currentMana = maxMana;
        BarSize = manaBar.sizeDelta.x;
	}

    private void Update()
    {
        float sizePercentage = BarSize * ((float)currentMana / (float)maxMana);
        Debug.Log("Mana Size : " + sizePercentage);
        manaBar.sizeDelta = new Vector2(sizePercentage, manaBar.sizeDelta.y);
    }

    public bool UseMana(int ManaUsed)
    {
        if (currentMana - ManaUsed < 0)
        {
            return false;
        }
        else
        {
            currentMana -= ManaUsed;
            return true;
        }
    }

    public void recoverMana(int ManaGain)
    {
        currentMana += ManaGain;
        if (currentMana > maxMana)
        {
            currentMana = maxMana;
        }
    }
	
}
