using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public bool isPaused;

    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPaused){
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }else{
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void SetPauseMenu(){
        if(!isPaused){
            isPaused = true;
        }else if(isPaused){
            isPaused = false;
        }else{
            isPaused = false;
        }
    }
}
