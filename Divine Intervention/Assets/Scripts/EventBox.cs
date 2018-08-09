using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventBox : MonoBehaviour {

    [SerializeField]
    GameObject sceneButton;//Restart/Next Scene button
    [SerializeField]
    GameObject quitButton;
    [SerializeField]
    GameObject eventText;
    [SerializeField]
    GameObject UI;
    [SerializeField]
    private string currentScene;//Current Level Scene
    private string loadScene;//Scene to be loaded when button clicked
    //public AudioClip deathsound;
    //public AudioClip winsound;
    public void pauseGame(bool paused)
    {
        loadScene = currentScene;
        UI.SetActive(!paused);
        //AudioSource[] allaudio = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        if (paused) 
        {
            /*foreach (AudioSource audio in allaudio)
            {
                audio.Pause();
            }*/
            Time.timeScale = 0;
            eventText.GetComponent<Text>().text = "Paused\nEsc to Resume";
            sceneButton.GetComponent<Text>().text = "Restart";
        }
        else
        {
            /*foreach (AudioSource audio in allaudio)
            {
                audio.UnPause();
            }*/
            Time.timeScale = 1;
        }
    }
    public void gameOver(int Score)
    {
        /*AudioSource[] allaudio = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach(AudioSource audio in allaudio)
        {
            audio.Pause();
        }
        GetComponent<AudioSource>().PlayOneShot(deathsound);*/
        Time.timeScale = 0;
        UI.SetActive(false);
        eventText.GetComponent<Text>().text = "Game Over!\nScore : " + Score;
        sceneButton.GetComponent<Text>().text = "New Game";
        loadScene = currentScene;
    }
    
    public void ChangeScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(loadScene);
    }
    public void exitGame()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}
