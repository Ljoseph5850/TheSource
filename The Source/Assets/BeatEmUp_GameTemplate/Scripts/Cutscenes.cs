using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cutscenes : MonoBehaviour
{

    //public float startTime, endTime;
    //private float countingTime;
    public static Cutscenes instance { get; private set; }

    // Use this for initialization
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        //countingTime = startTime;
        Invoke("LoadMenu", 5);

    }

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("SceneOne");
    }

    /*public void ShowLeaderboards()
    {
        PlayServices.ShowLeaderboardsUI();
    }
    
    public void ShowAchievements()
    {
        PlayServices.instance.ShowAchievementsUI();
    }*/

    // Update is called once per frame
    /*void Update()
    {

        countingTime += Time.deltaTime;
        
        if (countingTime >= endTime)
        {

            SceneManager.LoadScene(sceneName);

        }
    }*/

}