using UnityEngine;
using System.Collections;

public class LevelInit : MonoBehaviour {

	public string LevelMusic = "Music";
	public bool playMusic = true;
	public bool destroyLogo = false;

	public bool isKeyboard, isJoystick;

	public GameObject keyButton, joyButton;
	
	private GameObject audioplayer;
	private GameSettings settings;

	void Update(){
		if(isKeyboard){
			InputManager.SetKeyboard();
		}else if(isJoystick){
			InputManager.SetJoystick();
		}
	}

	void Awake() {

		//set settings
		settings = Resources.Load("GameSettings", typeof(GameSettings)) as GameSettings;
		if(settings != null){
			Time.timeScale = settings.timeScale;
			Application.targetFrameRate = settings.framerate;
		}

		//create Audio Player
		if(!GameObject.FindObjectOfType<AudioPlayer>())	audioplayer = GameObject.Instantiate(Resources.Load("AudioPlayer"), Vector3.zero, Quaternion.identity) as GameObject;

		//create InputManager
		if(!GameObject.FindObjectOfType<InputManager>()) GameObject.Instantiate(Resources.Load("InputManager"), Vector3.zero, Quaternion.identity);

		//create UI
		if(!GameObject.FindGameObjectWithTag("UI"))	GameObject.Instantiate(Resources.Load("UI"), Vector3.zero, Quaternion.identity);
	
		//create Game Camera
		if(!GameObject.FindObjectOfType<CameraFollow>()) GameObject.Instantiate(Resources.Load("GameCamera"), new Vector3(0,0,-10), Quaternion.identity);

		//start music
		if(playMusic) Invoke("PlayMusic", .1f);
	}

	void PlayMusic(){
		if(audioplayer != null)	audioplayer.GetComponent<AudioPlayer>().playMusic(LevelMusic);
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
}