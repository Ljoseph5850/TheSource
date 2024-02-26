using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    public Text hiScoreText;

    public bool startGame;
    public static bool setScore;

    public float scoreCount, timeRunner;
    public float hiScoreCount = 0;
    public float timeScoreCount = 0;
    public static int submitScore;

    public GameObject levelOne, levelTwo, levelThree, levelFour, levelFive, levelSix, levelSeven, levelEight, levelNine, levelTen;
    public GameObject levelEleven, levelTwelve, levelThirteen, levelFourteen, levelFifteen, levelSixteen, levelSeventeen, levelEighteen, levelNineteen, levelTwenty;

    // Use this for initialization
    void Start() {

        if (PlayerPrefs.HasKey("HighScore") != null) {

            hiScoreCount = PlayerPrefs.GetFloat("HighScore");

        }

        if (PlayerPrefs.HasKey("TopTime") != null)
        {

            timeScoreCount = PlayerPrefs.GetFloat("TopTime");

        }

        if(startGame){
            StartGame();
        }

        setScore = false;

        levelOne.SetActive(true);
        levelTwo.SetActive(false);
        levelThree.SetActive(false);
        levelFour.SetActive(false);
        levelFive.SetActive(false);
        levelSix.SetActive(false);
        levelSeven.SetActive(false);
        levelEight.SetActive(false);
        levelNine.SetActive(false);
        levelTen.SetActive(false);
        levelEleven.SetActive(false);
        levelTwelve.SetActive(false);
        levelThirteen.SetActive(false);
        levelFourteen.SetActive(false);
        levelFifteen.SetActive(false);
        levelSixteen.SetActive(false);
        levelSeventeen.SetActive(false);
        levelEighteen.SetActive(false);
        levelNineteen.SetActive(false);
        levelTwenty.SetActive(false);

        //theAchievementManager = FindObjectOfType<AchievementManager>();

        //introJump = 0;
        scoreCount = PlayerPrefs.GetFloat("CurrentScore");
        timeRunner = PlayerPrefs.GetFloat("CurrentTime");

    }

    // Update is called once per frame
    void Update() {


        PlayerPrefs.SetFloat("CurrentScore", scoreCount);
        //PlayerPrefs.SetFloat("CurrentTime", timeRunner);

        if(setScore)
        {
            scoreCount++;
            setScore = false;
        }

        if(startGame){
            StartGame();
            startGame = false;
        }

        if (scoreCount > hiScoreCount) {

            hiScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", hiScoreCount);

        }

        if (timeRunner > timeScoreCount)
        {

            timeScoreCount = timeRunner;
            PlayerPrefs.SetFloat("TopTime", hiScoreCount);

        }

        submitScore = Convert.ToInt32(hiScoreCount);

        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        //timeRunnerText.text = "Time: " + timeRunner;
        hiScoreText.text = "High Score: " + Mathf.Round(hiScoreCount);

        if(hiScoreCount > 2){
            levelTwo.SetActive(true);
        }if(hiScoreCount > 3){
            levelThree.SetActive(true);
        }if(hiScoreCount > 4){
            levelFour.SetActive(true);
        }if(hiScoreCount > 5){
            levelFive.SetActive(true);
        }if(hiScoreCount > 6){
            levelSix.SetActive(true);
        }if(hiScoreCount > 7){
            levelSeven.SetActive(true);
        }if(hiScoreCount > 8){
            levelEight.SetActive(true);
        }if(hiScoreCount > 9){
            levelNine.SetActive(true);
        }if(hiScoreCount > 10){
            levelTen.SetActive(true);
        }if(hiScoreCount > 11){
            levelEleven.SetActive(true);
        }if(hiScoreCount > 12){
            levelTwelve.SetActive(true);
        }if(hiScoreCount > 13){
            MainMenu.SetLevelThree();
            levelThirteen.SetActive(true);
        }if(hiScoreCount > 14){
            levelFourteen.SetActive(true);
        }if(hiScoreCount > 15){
            levelFifteen.SetActive(true);
        }if(hiScoreCount > 16){
            levelSixteen.SetActive(true);
        }if(hiScoreCount > 17){
            levelSeventeen.SetActive(true);
        }if(hiScoreCount > 18){
            levelEighteen.SetActive(true);
        }if(hiScoreCount > 19){
            levelNineteen.SetActive(true);
        }if(hiScoreCount > 20){
            levelTwenty.SetActive(true);
        }

        if(!startGame){
            if(hiScoreCount >= 2 && hiScoreCount < 7){
                MainMenu.SetLevelOne();
            }else if(hiScoreCount >= 7 && hiScoreCount < 11){
                MainMenu.SetLevelTwo();
            }else if(hiScoreCount >= 11 && hiScoreCount < 16){
                MainMenu.SetLevelThree();
            }else if(hiScoreCount >= 16){
                MainMenu.SetLevelFour();
            }
        }
    }

    public void AddScore(int pointsToAdd){

		scoreCount += pointsToAdd;

	}

    public void StartGame(){
        scoreCount = 0;
    }
    
    public void LevelIsOne(){
        scoreCount = 1;
    }
    public void LevelIsTwo(){
        scoreCount = 2;
    }
    public void LevelIsThree(){
        scoreCount = 3;
    }
    public void LevelIsFour(){
        scoreCount = 4;
    }
    public void LevelIsFive(){
        scoreCount = 5;
    }
    public void LevelIsSix(){
        scoreCount = 6;
    }
    public void LevelIsSeven(){
        scoreCount = 7;
    }
    public void LevelIsEight(){
        scoreCount = 8;
    }
    public void LevelIsNine(){
        scoreCount = 9;
    }
    public void LevelIsTen(){
        scoreCount = 10;
    }
    public void LevelIsEleven(){
        scoreCount = 11;
    }
    public void LevelIsTwelve(){
        scoreCount = 12;
    }
    public void LevelIsThirteen(){
        scoreCount = 13;
    }
    public void LevelIsFourteen(){
        scoreCount = 14;
    }
    public void LevelIsFifteen(){
        scoreCount = 15;
    }
    public void LevelIsSixteen(){
        scoreCount = 16;
    }
    public void LevelIsSeventeen(){
        scoreCount = 17;
    }
    public void LevelIsEighteen(){
        scoreCount = 18;
    }
    public void LevelIsNineteen(){
        scoreCount = 19;
    }
    public void LevelIsTwenty(){
        scoreCount = 20;
    }

    public void Reset()
    {
        hiScoreCount = 0;
    }

    public static void SetScore(){
        setScore = true;
    }
}
