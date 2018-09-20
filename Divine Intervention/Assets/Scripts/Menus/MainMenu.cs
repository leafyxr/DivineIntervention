using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public string LoadScene;
    [SerializeField]
    private GameObject Main;
    [SerializeField]
    private GameObject Blacksmith;
    [SerializeField]
    private GameObject Church;
    [SerializeField]
    private GameObject Settings;
    [SerializeField]
    Text GoldCount;
    private DataManager dataManager;
    // Use this for initialization
    void Start () {
        dataManager = FindObjectOfType<DataManager>().GetComponent<DataManager>();
        main();
	}

    private void Update()
    {
        
        if (GoldCount != null)
        {
            GoldCount.text = dataManager.data.Gold.ToString();
        }
    }
    public void StartButton()
    {
        Debug.Log("This 2; Time: " + Time.realtimeSinceStartup + " Progression " + dataManager.data.Progression);
        SceneManager.LoadScene(LoadScene);
    }

    public void exitGame()
    {
        Application.Quit();
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
