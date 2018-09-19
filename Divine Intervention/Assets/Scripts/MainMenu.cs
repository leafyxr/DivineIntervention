using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public string LoadScene;
    [SerializeField]
    private GameObject titleScreen;
    [SerializeField]
    private GameObject Main;
    [SerializeField]
    private GameObject Blacksmith;
    [SerializeField]
    private GameObject Church;
    [SerializeField]
    private GameObject Settings;
    public bool showtitle = true;
    [SerializeField]
    Text GoldCount;
    // Use this for initialization
    void Start () {
        titleScreen.SetActive(showtitle);
        if (showtitle)
        {
            Main.SetActive(false);
            Blacksmith.SetActive(false);
            Church.SetActive(false);
            Settings.SetActive(false);
        }
	}

    private void Update()
    {
        if (showtitle)
        {
            if (Input.anyKeyDown)
            {
                showtitle = false;
                titleScreen.SetActive(showtitle);
                Main.SetActive(true);
            }
        }
        if (GoldCount != null)
        {
            GoldCount.text = FindObjectOfType<DataManager>().GetComponent<DataManager>().data.Gold.ToString();
        }
    }
    public void StartButton()
    {
        if (!showtitle) { SceneManager.LoadScene(LoadScene); }
    }

    public void exitGame()
    {
        if (!showtitle) { Application.Quit(); }
    }

    public void blacksmith()
    {
        Main.SetActive(false);
        Blacksmith.SetActive(true);
        Church.SetActive(false);
        Settings.SetActive(false);
    }
    public void main()
    {
        Main.SetActive(true);
        Blacksmith.SetActive(false);
        Church.SetActive(false);
        Settings.SetActive(false);
    }
    public void church()
    {
        Main.SetActive(false);
        Blacksmith.SetActive(false);
        Church.SetActive(true);
        Settings.SetActive(false);
    }
    public void settings()
    {
        Main.SetActive(false);
        Blacksmith.SetActive(false);
        Church.SetActive(false);
        Settings.SetActive(true);
    }
}
