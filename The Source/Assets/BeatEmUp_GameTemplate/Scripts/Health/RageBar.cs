using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class RageBar : MonoBehaviour
{
    public Text nameField;
	public Slider RpSlider;
	public bool isPlayer;
	//public Image[] healthPoints;
	
	//float health;

	void OnEnable() {
		RageSystem.onRageChange += UpdateRage;
	}

	void OnDisable() {
		RageSystem.onRageChange -= UpdateRage;
	}

	void Start(){
		RpSlider.gameObject.SetActive(isPlayer);
	}

	void UpdateRage(float percentage, GameObject go){
		if(isPlayer && go.CompareTag("Player")){
			RpSlider.value = percentage;
		} 	

		if(!isPlayer && go.CompareTag("Enemy")){
			RpSlider.gameObject.SetActive(true);
			RpSlider.value = percentage;
			nameField.text = go.GetComponent<Enemy>().enemyName;
			if(percentage == 0) Invoke("HideOnDestroy", 2);
			
			/*for(int i = 0; i < healthPoints.Length; i++){
				healthPoints[i].enabled = !DisplayHealthPoint(HpSlider.value, i);
			}*/
		}
	}
	
	/*bool DisplayHealthPoint(float _health, int pointNumber){
		return ((pointNumber * 10) >= _health);
	}*/

	void HideOnDestroy(){
		RpSlider.gameObject.SetActive(false);
		nameField.text = "";
	}
}
