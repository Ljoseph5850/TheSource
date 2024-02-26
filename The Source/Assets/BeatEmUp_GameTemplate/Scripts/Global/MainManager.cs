using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour {

	public string playGameLevel;
    public string previousGameLevel;

    private void Update()
    {
        /*if (Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene(playGameLevel);
            //Application.LoadLevel (playGameLevel);
            //PlayerPrefs.SetFloat("CurrentCoin", 0);
            //PlayerPrefs.SetFloat("CurrentScore", 0);
        }*/
        if(Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene(playGameLevel);
            //Application.LoadLevel (playGameLevel);
            //PlayerPrefs.SetFloat("CurrentCoin", 0);
            //PlayerPrefs.SetFloat("CurrentScore", 0);
        }
        /*if(Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene(playGameLevel);
            //Application.LoadLevel (playGameLevel);
            //PlayerPrefs.SetFloat("CurrentCoin", 0);
            //PlayerPrefs.SetFloat("CurrentScore", 0);
        }*/
    }

    public void PlayGame () {

        SceneManager.LoadScene(playGameLevel);
        //Application.LoadLevel (playGameLevel);
        //PlayerPrefs.SetFloat("CurrentCoin", 0);
        //PlayerPrefs.SetFloat("CurrentScore", 0);

    }

    public void NextLevel () {

        SceneManager.LoadScene(previousGameLevel);
        //Application.LoadLevel (playGameLevel);
        //PlayerPrefs.SetFloat("CurrentCoin", 0);
        //PlayerPrefs.SetFloat("CurrentScore", 0);

    }

    public void QuitGame () {

		Application.Quit ();

	}
}
