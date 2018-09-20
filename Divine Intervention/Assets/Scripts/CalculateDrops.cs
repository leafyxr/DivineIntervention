using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateDrops : MonoBehaviour
{
    public ItemDrop[] Drops;
    public float spawnRangeMin = .1f;
    public float spawnRangeMax = .1f;
    public void DropItems()
    {
        foreach (ItemDrop item in Drops)
        {
            for (int i = 0; i < item.maxSpawns; i++)
            {
                if (Random.value > 1 - item.spawnChance)
                {
                    float xRand = Random.Range(-spawnRangeMin, spawnRangeMax) + transform.position.x;
                    float yRand = Random.Range(-spawnRangeMin, spawnRangeMax) + transform.position.y;
                    Vector2 spawnLocation = new Vector2(xRand, yRand);
                    Instantiate(item.Item, spawnLocation, transform.rotation);
                    Debug.Log("Item Dropped");
                }
            }
        }
    }
}



