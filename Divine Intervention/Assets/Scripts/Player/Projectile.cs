using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    private int Damage;
    [SerializeField]
    private GameObject Explosion;
    private void Start()
    {
        Damage = FindObjectOfType<PlayerController>().Playerstats.RangedPower;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Destructable"))
        {
            Instantiate(Explosion, transform.position, transform.rotation);
            collision.gameObject.GetComponent<DestroyObject>().destroy();
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(Explosion, transform.position, transform.rotation);
            if (collision.gameObject.GetComponent<MeleeEnemy>().takeDamage(Damage))
            {
                Debug.Log("Enemy Killed");
                FindObjectOfType<PlayerController>().addScore(1);
            }
            Destroy(gameObject);
        }
        else if (!collision.gameObject.CompareTag("Player"))
        {
            Instantiate(Explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

}
