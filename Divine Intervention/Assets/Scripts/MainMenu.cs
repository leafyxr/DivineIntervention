﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public string LoadScene;
    [SerializeField]
    private GameObject titleScreen;
    public bool showtitle = true;
    // Use this for initialization
    void Start () {

	}

    private void Update()
    {
        if (showtitle)
        {
            if (Input.anyKeyDown)
            {
                showtitle = false;
                titleScreen.SetActive(showtitle);
            }
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
}