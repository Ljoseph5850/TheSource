using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoundClearScrn : MonoBehaviour {

	public Text text;
	public Text randomText;
	public Gradient ColorTransition;
	public float speed = 3.5f;
	public UIFader fader;
	public GameObject gameLogo;
	
	public MainMenu theMainMenu;
	
	private bool restartInProgress = false;
	private bool tryAgain;

	private int levelNumber;

	// Array of random sayings
    public string[] randomSayings = {
        "To see level progression click the Pause Button",
        "A power move will provide you stronger, and more long ranged attacks, press 'X' to use power moves",
        "The defend button will give you a window to attack enemies after they attack",
        "Never give up, the fate of the universe is in your hands!",
        "You can move while defending, use this to get out of danger",
        "If you run out of power energy, your power bar will flash white",
        "Hit the crate and blue barrel for more health pickups",
		"If the enemy runs off screen back up and wait for them to come back",
        "You’re a Champion, You can do it!"
    };

	void Start(){
		HideText();
		theMainMenu = FindObjectOfType<MainMenu>();
	}

	void OnEnable() {
		EnemyWaveSystem.onLevelComplete += ShowLevelCompleteScrn;
		InputManager.onCombatInputEvent += InputEvent;
	}

	void OnDisable() {
		EnemyWaveSystem.onLevelComplete -= ShowLevelCompleteScrn;
		InputManager.onCombatInputEvent -= InputEvent;
	}

	void ShowLevelCompleteScrn(){
		fader.Fade(UIFader.FADE.FadeOut, .5f, 1);
		Invoke("ShowText", 1.4f);
	}

	void ShowText(){
		text.gameObject.SetActive(true);
		// Display random saying in the second text variable
        string randomSaying = GetRandomSaying();
        randomText.text = randomSaying;
	}

	void HideText(){
		text.gameObject.SetActive(false);
		randomText.text = ""; // Clear random text
	}

	//restart level on button press
	void InputEvent(string action){
		if(text.gameObject.activeSelf){ 
			RestartLevel();
		}
	}

	void Update(){

		//text effect
		if(text != null && text.gameObject.activeSelf){
			float t = Mathf.PingPong(Time.time * speed, 1f);
			text.color = ColorTransition.Evaluate(t);
		}

		//restart button pressed
		if(Input.GetMouseButtonDown(0) && text.gameObject.activeSelf){
			RestartLevel();
		}
		
		if(tryAgain){
			theMainMenu.SetLogo();
		}		
	}
	
	public void activateLevelSelect(int leveToAdd)
    {
        levelNumber += leveToAdd;
		ScoreManager.SetScore();
    }

	//restarts the current level
	void RestartLevel(){
		if(!restartInProgress){
			restartInProgress = true;
			GlobalAudioPlayer.PlaySFX("ButtonStart");

			//button flicker
			ButtonFlicker bf =  GetComponentInChildren<ButtonFlicker>();
			if(bf != null) bf.StartButtonFlicker();
			
			//levelNumber += 1;
			if(levelNumber > 1){
				//MainMenu.SetLevelOne();
			}

			if(levelNumber > 5 && levelNumber < 10){
				//MainMenu.SetLevelTwo();
				Debug.Log("Level 6 Starter!");
				GameOverScrn.LevelSixStart();
			}else if (levelNumber > 10 && levelNumber < 15){
				//MainMenu.SetLevelThree();
				Debug.Log("Level 11 Starter!");
				GameOverScrn.LevelElevenStart();
			}else if (levelNumber > 15){
				//MainMenu.SetLevelFour();
				Debug.Log("Level 16 Starter!");
				GameOverScrn.LevelSixTeenStart();
			}

			Invoke("RestartScene", 1f);
		}
	}

	void RestartScene(){
		theMainMenu.SetLogo();
		SceneManager.LoadScene("Game" + levelNumber);
	}
	
	public void setTry(){
		tryAgain = true;
	}

	// Method to get a random saying from the array
    string GetRandomSaying(){
        int index = Random.Range(0, randomSayings.Length);
        return randomSayings[index];
    }
}
