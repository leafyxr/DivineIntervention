using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    [SerializeField]
    RectTransform healthBar;
    [SerializeField]
    private GameObject blood;
    private int currentHealth;
    private int maxHealth;
    private float BarSize;
    private GameObject player;
    private Stats playerStats;

    void Start()
    {
        BarSize = healthBar.sizeDelta.x;
        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<PlayerController>().Playerstats;
        maxHealth = playerStats.Health;
        currentHealth = maxHealth;
    }

    private void Update()
    {
        float sizePercentage = BarSize * ((float)currentHealth / (float)maxHealth);
        Debug.Log("Health Size : " + sizePercentage);
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
            currentHealth -= (int)(DamageTaken*(1-(playerStats.Resistance/100)));
            Debug.Log("currentHealth =" + currentHealth);
        }
        playerStats.Health = currentHealth;
    }

    public void regenHealth(int HealthGain)
    {
        currentHealth += HealthGain;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        playerStats.Health = currentHealth;
        Debug.Log("currentHealth =" + currentHealth);
    }
}
