using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldDrop : MonoBehaviour {
    public bool isRandom = false;
    public int maxRandValue = 100;
    public int minRandValue = 10;

    public int defaultValue = 50;
    [SerializeField]
    private GameObject gold;
    public float spawnRangeMin = .1f;
    public float spawnRangeMax = .1f;


    public void dropGold()
    {
        int value = defaultValue;
        if (isRandom)
        {
            value = (int)Random.Range(minRandValue, maxRandValue);
        }
        float xRand = Random.Range(-spawnRangeMin, spawnRangeMax) + transform.position.x;
        float yRand = Random.Range(-spawnRangeMin, spawnRangeMax) + transform.position.y;
        Vector2 spawnLocation = new Vector2(xRand, yRand);
        GameObject drop = Instantiate(gold, spawnLocation, transform.rotation);
        drop.GetComponent<GoldCollect>().Value = value;
        Debug.Log(value + " Gold Dropped");
    }
}
