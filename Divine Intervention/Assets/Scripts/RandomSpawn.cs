using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour {
    [SerializeField]
    private GameObject spawnObject;
    private GameObject[] gameObjects;
    public float xMax = 1;
    public float xMin = 1;
    public float yMax = 1;
    public float yMin = 1;
    public bool exponential = false;
    public float MinSpawnTime = 2;
    private float timeDelay = 3;
    public float MaxSpawnTime = 100;
    private float Delayclock = 0;
    private float Spawnerclock = 0;
    public int maxSpawns = 10;
    private int currentSpawns = 0;
    [SerializeField]
    private bool active = true;
    void Start () {
        gameObjects = new GameObject[maxSpawns];
	}
	
	// Update is called once per frame
	void Update () {
        if (exponential && active)
        {
            Spawnerclock += Time.deltaTime;
            timeDelay = MaxSpawnTime / Mathf.Sqrt(1+Mathf.Pow(Spawnerclock, 2)) + MinSpawnTime;
        }
        if (Delayclock == 0 && active)
        {
            bool spawned = false;
            for(int i = 0; i<maxSpawns; i++)
            {
                if(gameObjects[i] == null && !spawned)
                {
                    spawn(i);
                    spawned = true;
                }
            }
        }
        else if (active)
        {
            Delayclock += Time.deltaTime;
            if (Delayclock >= timeDelay)
            {
                Delayclock = 0;
            }
        }
	}

    private void spawn(int i)
    {
        Debug.Log("Object Spawned, Time Delay = " + timeDelay);
        float xRand = Random.Range(xMin, xMax) + transform.position.x;
        float yRand = Random.Range(yMin, yMax) + transform.position.y;
        Vector2 spawnLocation = new Vector2(xRand, yRand);
        gameObjects[i]=(GameObject)Instantiate(spawnObject, spawnLocation, transform.rotation);
        Delayclock += Time.deltaTime;
    }

    public void ObjectDestroyed()
    {
        currentSpawns--;
    }

    public bool toggle()
    {
        active = !active;
        return active;
    }
}
