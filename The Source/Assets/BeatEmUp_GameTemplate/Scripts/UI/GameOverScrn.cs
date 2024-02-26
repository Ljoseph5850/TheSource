using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScrn : MonoBehaviour {

	public Text text;
	public Text randomText;
	public GameObject gameOverWord, gameOverWordShadow;
	public Gradient ColorTransition;
	public float speed = 3.5f;
	public static bool gameSix;
	public static bool gameEleven;
	public static bool gameSixTeen;
	public UIFader fader;
	private bool restartInProgress = false;

	private int levelNumber;

	// Array of random sayingss
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
		gameOverWord.SetActive(false);
		gameOverWordShadow.SetActive(false);
	}

	void OnEnable() {
		PlayerCombat.OnPlayerDeath += ShowGameOverScrn;
		InputManager.onCombatInputEvent += InputEvent;
	}

	void OnDisable() {
		PlayerCombat.OnPlayerDeath -= ShowGameOverScrn;
		InputManager.onCombatInputEvent -= InputEvent;
	}

	void ShowGameOverScrn(){
		fader.Fade(UIFader.FADE.FadeOut, .5f, 1);
		Invoke("ShowText", 1.4f);
	}

	void ShowText(){
		text.gameObject.SetActive(true);
		//gameOverWord.SetActive(true);
		//gameOverWordShadow.SetActive(true);
		// Display random saying in the second text variable
        string randomSaying = GetRandomSaying();
        randomText.text = randomSaying;
	}

	void HideText(){
		text.gameObject.SetActive(false);
		randomText.text = ""; // Clear random text
		gameOverWord.SetActive(false);
		gameOverWordShadow.SetActive(false);
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
	}

	public void activateLevelSelect(int leveToAdd)
    {
        levelNumber += leveToAdd;
    }

	//restarts the current level
	void RestartLevel(){
		if(!restartInProgress){
			restartInProgress = true;

			//sfx
			GlobalAudioPlayer.PlaySFX("ButtonStart");

			//button flicker
			ButtonFlicker bf =  GetComponentInChildren<ButtonFlicker>();
			if(bf != null) bf.StartButtonFlicker();

			Invoke("RestartScene", 1f);
		}
	}

	void RestartScene(){
		/*if(gameSixTeen){
			SceneManager.LoadScene("Game16");
		}else if(gameEleven){
			SceneManager.LoadScene("Game11");
		}else if(gameSix){
			SceneManager.LoadScene("Game6");
		}else{
			SceneManager.LoadScene("Game");
		}*/
		if(levelNumber == 0){
			SceneManager.LoadScene("Game");
		}else{
			SceneManager.LoadScene("Game" + levelNumber);
		}	
	}

	public static void LevelSixStart(){
		gameSix = true;
	}

	public static void LevelElevenStart(){
		gameEleven = true;
	}

	public static void LevelSixTeenStart(){
		gameSixTeen = true;
	}

	// Method to get a random saying from the array
    string GetRandomSaying(){
        int index = Random.Range(0, randomSayings.Length);
        return randomSayings[index];
    }
}
