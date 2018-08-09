using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    [SerializeField]
    private int maxHealth = 100;
    [SerializeField]
    RectTransform healthBar;
    [SerializeField]
    private GameObject blood;
    private int currentHealth;
    private float BarSize;
    private GameObject player;

    void Start()
    {
        currentHealth = maxHealth;
        BarSize = healthBar.sizeDelta.x;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        float sizePercentage = BarSize * ((float)currentHealth / (float)maxHealth);
        Debug.Log("Mana Size : " + sizePercentage);
        healthBar.sizeDelta = new Vector2(sizePercentage, healthBar.sizeDelta.y);
    }

    public void TakeDamage(int DamageTaken)
    {
        Instantiate(blood, player.transform.position, player.transform.rotation);
        if (currentHealth - DamageTaken < 0)
        {
            Debug.Log("Game Over");
            player.GetComponent<PlayerController>().EndGame();
        }
        else
        {
            currentHealth -= DamageTaken;
        }
    }

    public void regenHealth(int HealthGain)
    {
        currentHealth += HealthGain;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
