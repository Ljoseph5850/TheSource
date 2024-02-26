using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour {

	public Text nameField;
	public Slider HpSlider;
	public bool isPlayer, isPlayerTwo;
	public Image[] healthPoints;
	
	float health;

	void OnEnable() {
		HealthSystem.onHealthChange += UpdateHealth;
	}

	void OnDisable() {
		HealthSystem.onHealthChange -= UpdateHealth;
	}

	void Start(){
		HpSlider.gameObject.SetActive(isPlayer);
	}

	void UpdateHealth(float percentage, GameObject go){
		if(isPlayer && go.CompareTag("Player")){
			HpSlider.value = percentage;
		}

		//Player Two tag info
		if(isPlayerTwo && go.CompareTag("PlayerTwo")){
			HpSlider.value = percentage;
		} 	

		if(!isPlayer && go.CompareTag("Enemy")){
			HpSlider.gameObject.SetActive(true);
			HpSlider.value = percentage;
			//nameField.text = go.GetComponent<Enemy>().enemyName;
			if(percentage == 0) Invoke("HideOnDestroy", 2);
			
			for(int i = 0; i < healthPoints.Length; i++){
				healthPoints[i].enabled = !DisplayHealthPoint(HpSlider.value, i);
			}
		}
	}
	
	bool DisplayHealthPoint(float _health, int pointNumber){
		return ((pointNumber * 10) >= _health);
	}

	void HideOnDestroy(){
		HpSlider.gameObject.SetActive(false);
		nameField.text = "";
	}
}
