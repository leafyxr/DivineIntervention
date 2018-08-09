using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour {
    private GameObject player;
    [SerializeField]
    private HealthBar playerhealth;
    private Rigidbody2D body;
    public int DamageDealt = 10;
    [SerializeField]
    private int maxHealth = 5;
    [SerializeField]
    private float speed = 2;
    private int currentHealth;
    [SerializeField]
    private GameObject blood;
    [SerializeField]
    private float attackDelay = 1;
    private float clock = 0;
	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
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
        direction.Normalize();
        body.velocity = (direction * speed);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, body.velocity);
    }

    public bool takeDamage(int DamageTaken)
    {
        currentHealth -= DamageTaken;
        Instantiate(blood, transform.position, transform.rotation);
        if (currentHealth <= 0)
        {
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
                playerhealth.TakeDamage(DamageDealt);
                clock += Time.deltaTime;
                body.AddForce(-body.velocity);
            }

        }
    }
}
