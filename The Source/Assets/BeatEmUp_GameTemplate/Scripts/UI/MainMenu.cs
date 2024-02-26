using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public UIFader UI_Fader;
	private GameSettings settings;
	private bool startGameInProgress = false;
	public static bool levelContOne, levelContTwo, levelContThree, levelContFour;
	public bool setLogo;
	public bool isKeyboard, isJoystick;
	public GameObject keyButton, joyButton;
	public GameObject gameLogo;
	public GameObject nextLevelText;
	public GameObject planetListOne;
	public GameObject planetListTwo;
	public GameObject planetListThree;
	public GameObject planetListFour;

	void OnEnable() {
		InputManager.onCombatInputEvent += InputEvent;
	}

	void OnDisable() {
		InputManager.onCombatInputEvent -= InputEvent;
	}

	void InputEvent(string action){
			StartGame();
	}

	void Start(){
		planetListOne.SetActive(false);
		planetListTwo.SetActive(false);
		planetListThree.SetActive(false);
		planetListFour.SetActive(false);
		//Start fade in
		Invoke("FadeIn", 1f);
	}
	
	void Update(){
		if(!setLogo){
			planetListOne.SetActive(false);
			planetListTwo.SetActive(false);
			planetListThree.SetActive(false);
			planetListFour.SetActive(false);
		}else if(levelContOne && setLogo){
			planetListOne.SetActive(true);
			planetListTwo.SetActive(false);
			planetListThree.SetActive(false);
			planetListFour.SetActive(false);
		}else if(levelContTwo && setLogo){
			planetListOne.SetActive(false);
			planetListTwo.SetActive(true);
			planetListThree.SetActive(false);
			planetListFour.SetActive(false);
		}else if(levelContThree && setLogo){
			planetListOne.SetActive(false);
			planetListTwo.SetActive(false);
			planetListThree.SetActive(true);
			planetListFour.SetActive(false);
		}else if(levelContFour && setLogo){
			planetListOne.SetActive(false);
			planetListTwo.SetActive(false);
			planetListThree.SetActive(false);
			planetListFour.SetActive(true);
		}

		if(setLogo){
			gameLogo.SetActive(false);
			nextLevelText.SetActive(true);
		}

		if(isKeyboard){
			InputManager.SetKeyboard();
		}else if(isJoystick){
			InputManager.SetJoystick();
		}
	}

	public void StartGame(){
		if(!startGameInProgress){

			startGameInProgress = true;

			//play sfx
			GlobalAudioPlayer.PlaySFX("ButtonStart");

			//flicker button
			ButtonFlicker bf =  GetComponentInChildren<ButtonFlicker>();
			if(bf != null) bf.StartButtonFlicker();

			//fade out
			FadeOut();

			//start Game
			Invoke("startGame", 1.8f);
		}
	}

	void FadeIn(){
		UI_Fader.Fade(UIFader.FADE.FadeIn, .5f, 0f);
	}

	void FadeOut(){
		UI_Fader.Fade(UIFader.FADE.FadeOut, .5f, 1f);
	}

	//Start game
	void startGame(){
		FadeIn();
		gameObject.SetActive(false);

		//start 1st enemy wave
		EnemyWaveSystem EWS = GameObject.FindObjectOfType<EnemyWaveSystem>();
		if(EWS != null) EWS.OnLevelStart();
	}
	
	public void SetLogo(){
		setLogo = true;
	}

	public void TheKeyboard(){
		isKeyboard = true;
		isJoystick = false;
		keyButton.SetActive(false);
		joyButton.SetActive(true);
	}

	public void TheJoystick(){
		isJoystick = true;
		isKeyboard = false;
		joyButton.SetActive(false);
		keyButton.SetActive(true);
	}

	public static void SetLevelOne(){
		levelContOne = true;
	}

	public static void SetLevelTwo(){
		levelContOne = false;
		levelContTwo = true;
	}

	public static void SetLevelThree(){
		levelContOne = false;
		levelContTwo = false;
		levelContThree = true;
	}

	public static void SetLevelFour(){
		levelContOne = false;
		levelContTwo = false;
		levelContThree = false;
		levelContFour = true;
	}
}