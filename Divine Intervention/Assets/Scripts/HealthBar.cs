using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    [SerializeField]
    RectTransform healthBar;
    [SerializeField]
    private GameObject blood;
    private int currentHealth;
    private float BarSize;
    private GameObject player;
    private Stats playerStats;

    void Start()
    {
        BarSize = healthBar.sizeDelta.x;
        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<PlayerController>().Playerstats;
        currentHealth = playerStats.Health;
    }

    private void Update()
    {
        float sizePercentage = BarSize * ((float)currentHealth / (float)playerStats.Health);
        Debug.Log("Mana Size : " + sizePercentage);
        healthBar.sizeDelta = new Vector2(sizePercentage, healthBar.sizeDelta.y);
    }

    public void TakeDamage(int DamageTaken)
    {
        Instantiate(blood, player.transform.position, player.transform.rotation);
        if (currentHealth - DamageTaken <= 0)
        {
            Debug.Log("Game Over");
            player.GetComponent<PlayerController>().EndGame();
        }
        else
        {
            currentHealth -= (int)(DamageTaken*(1-(1/playerStats.Resistance)));
        }
    }

    public void regenHealth(int HealthGain)
    {
        currentHealth += HealthGain;
        if (currentHealth > playerStats.Health)
        {
            currentHealth = playerStats.Health;
        }
    }
}
