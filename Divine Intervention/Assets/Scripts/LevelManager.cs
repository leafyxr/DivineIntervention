using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
    public enum LevelType {TimeTrial, KillEnemies, ReachGoal, Survival};
    public LevelType type;
    private DataManager dataManager;
    private PlayerController player;
    public Text label;
    public Text Number;
    private bool StartMenuOpen = true;
    public GameObject startMenu;
    public Text TaskText;
    public Text InfoText;
    //TimeTrial  - do as much as you can in the allocated time
    private float timer;
    public float Timelimit;
    private int TimeRemaining;
    //ScoreBased - kill a certain number of enemies before they defeat you
    public int MaxEnemies;
    private int EnemiesRemaining;
    //ReachGoal - Reach the end of the level
    public GameObject TargetArea;
    //Survival - Survive for as long as possible (Time Survived influences score)
    private int Kills;
    private float timeSurvived;
	// Use this for initialization
	void Start () {
        startMenu.SetActive(true);
        player = FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
        dataManager = FindObjectOfType<DataManager>().GetComponent<DataManager>();
        if (type == LevelType.TimeTrial)
        {
            TaskText.text = "Task: Hold out for " + Timelimit + " seconds";
            InfoText.text = "You will earn extra gold based on the ammount of enemies defeated";
            label.text = "Time Left";
        }
        else if (type == LevelType.KillEnemies)
        {
            EnemiesRemaining = MaxEnemies - player.getScore();
            TaskText.text = "Task: You must Eliminate " + MaxEnemies + " Enemies";
            InfoText.text = "Defeat them before they defeat you";
            label.text = "Enemies Remaining";
        }
        else if (type == LevelType.ReachGoal)
        {
            TaskText.text = "Task: Reach the End";
            InfoText.text = "Find and reach the end of the dungeon, Bonus gold can be earned for enemies defeated";
            label.text = "Reach the";
            Number.text = "EXIT";
        }
        else if (type == LevelType.Survival)
        {
            TaskText.text = "Task: Hold out for as long as you can";
            InfoText.text = "Bonus gold can be earned based on time survived and enemies defeated";
            label.text = "Time Left";
        }
        Time.timeScale = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (StartMenuOpen)
        {
            if (Input.anyKeyDown)
            {
                StartMenuOpen = false;
                Time.timeScale = 1;
                startMenu.SetActive(false);
            }
        }
        else if (type == LevelType.TimeTrial)
        {
            timer += Time.deltaTime;
            TimeRemaining = (int)(Timelimit - timer);
            Number.text = TimeRemaining.ToString();
            if (TimeRemaining <= 0)
            {
                player.EndGame();
            }
        }
        else if (type == LevelType.KillEnemies)
        {
            EnemiesRemaining = MaxEnemies - player.getScore();
            Number.text = EnemiesRemaining.ToString();
            Debug.Log(EnemiesRemaining);
            if(EnemiesRemaining <= 0)
            {
                player.EndGame();
            }

        }
        else if (type == LevelType.ReachGoal)
        {

        }
        else if (type == LevelType.Survival)
        {

        }
    }
}
