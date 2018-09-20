using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour {
    private GameObject player;
    [SerializeField]
    private HealthBar playerhealth;
    private Rigidbody2D body;
    [SerializeField]
    private Stats enemyStats;
    private int currentHealth;
    [SerializeField]
    private GameObject blood;
    [SerializeField]
    private float attackDelay = 1;
    [SerializeField]
    private float FollowDistance = 10;
    private float clock = 0;
	// Use this for initialization
	void Start () {
        currentHealth = enemyStats.Health;
        player = GameObject.FindGameObjectWithTag("Player");
        body = GetComponent<Rigidbody2D>();
        playerhealth = GameObject.FindObjectOfType<HealthBar>();
    }
	
	// Update is called once per frame
	void Update () {
        if (clock != 0)
        {
            clock += Time.deltaTime;
            if (clock >= attackDelay)
            {
                clock = 0;
            }
        }
        Vector2 target = player.GetComponent<Transform>().position;
        Vector2 currentPos = transform.position;
        Vector2 direction = target - currentPos;
        if (Mathf.Abs(Vector2.Distance(transform.position, target)) < FollowDistance){
            direction.Normalize();
            body.velocity = (direction * enemyStats.Speed);
            transform.rotation = Quaternion.LookRotation(Vector3.forward, body.velocity);
        }

    }

    public bool takeDamage(int DamageTaken)
    {
        currentHealth -= (int)(DamageTaken * (1 - (enemyStats.Resistance/100)));
        Instantiate(blood, transform.position, transform.rotation);
        if (currentHealth <= 0)
        {
            CalculateDrops loot;
            if (loot = GetComponent<CalculateDrops>()){
                Debug.Log("Dropping...");
                loot.DropItems();
            }
            GoldDrop gold;
            if (gold = GetComponent<GoldDrop>())
            {
                Debug.Log("Dropping...");
                gold.dropGold();
            }
            GetComponent<DestroyObject>().destroy();
            return true;
        }
        return false;
    }

  private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (clock == 0)
            {
                GetComponent<Animator>().SetTrigger("Attack");
                playerhealth.TakeDamage(enemyStats.MeleePower);
                clock += Time.deltaTime;
                body.AddForce(-body.velocity);
            }

        }
    }
}
