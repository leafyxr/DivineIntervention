using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour {
    public float fireDelay = .1f;
    public float speed = 3;
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private ManaBar mana;
    private int manaUsed;
    private float clock = 0;
    private void Start()
    {
        manaUsed = FindObjectOfType<PlayerController>().Playerstats.MagicUse;
    }
    void Update () {
        if (clock != 0)
        {
            clock += Time.deltaTime;
            if (clock >= fireDelay)
            {
                clock = 0;
            }
        }
        if (Input.GetButton("Ranged"))
        {
            if (clock == 0)
            {
                if (mana.UseMana(manaUsed))
                {
                    Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);
                    Vector2 direction = target - currentPos;
                    direction.Normalize();
                    Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
                    GameObject projectileC = (GameObject)Instantiate(projectile, currentPos, rotation);
                    projectileC.GetComponent<Rigidbody2D>().velocity = direction * speed;
                    clock += Time.deltaTime;
                }
                
            }
        }
	}
}
