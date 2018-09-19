using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D playerBody;
    private Animator animator;
    [SerializeField]
    private ManaBar mana;
    private GameObject menu;
    [SerializeField]
    private Text ScoreText;
    public bool paused = false;
    private int iScore = 0;
    [SerializeField]
    public Stats Playerstats;
    public int ManaGain = 10;
    [SerializeField]
    private DataManager dataManager;
    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
        playerBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        menu = GameObject.FindGameObjectWithTag("EventMenu");
        if (paused)
        {
            menu.GetComponent<EventBox>().pauseGame(paused);
        }
        else
        {
            menu.SetActive(false);
        }
        Playerstats = dataManager.data.PlayerStats;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            paused = !paused;
            menu.SetActive(true);
            menu.GetComponent<EventBox>().pauseGame(paused);
            if (!paused)
            {
                menu.SetActive(false);
            }
        }
        if (Input.GetKeyDown("r"))
        {
            
        }
        playerBody.velocity = new Vector2(Input.GetAxis("Horizontal") * Playerstats.Speed, Input.GetAxis("Vertical") * Playerstats.Speed);
        if (Input.GetButtonDown("Melee"))
        {
            MeleeAttack();

        }
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        if (playerBody.velocity != Vector2.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, playerBody.velocity);
        }
    }

    public void EndGame()
    {
        menu.SetActive(true);
        menu.GetComponent<EventBox>().gameOver(iScore);
    }

    public void addScore(int Score)
    {
        iScore += Score;
        if (ScoreText != null)
        {
            ScoreText.text = iScore.ToString();
        }
        return;
    }


    private void MeleeAttack()
    {
        ContactFilter2D contactFilter2D = new ContactFilter2D();
        Collider2D[] colliders = new Collider2D[50];
        GetComponent<CircleCollider2D>().OverlapCollider(contactFilter2D, colliders);
        animator.SetTrigger("SwordAttack");
        foreach(Collider2D collider in colliders) {
            if (collider == null)
            {
                return;
            }
            if (collider.gameObject.CompareTag("Destructable"))
            {
                mana.recoverMana(ManaGain);
                collider.gameObject.GetComponent<DestroyObject>().destroy();
                return;
            }
            if (collider.gameObject.CompareTag("Enemy"))
            {
                mana.recoverMana(ManaGain);
                if (collider.gameObject.GetComponent<MeleeEnemy>().takeDamage(Playerstats.MeleePower))
                {
                    Debug.Log("Enemy Killed");
                    addScore(1);
                }
                return;
            }
        }
    }
}
