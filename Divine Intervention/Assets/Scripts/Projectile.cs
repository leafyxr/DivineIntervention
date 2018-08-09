using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public int Damage = 1;
    [SerializeField]
    private GameObject Explosion;
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
