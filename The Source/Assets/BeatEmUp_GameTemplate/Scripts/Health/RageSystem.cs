using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageSystem : MonoBehaviour
{
    public int MaxRp = 100;
	public int CurrentRp = 100;
	public bool invulnerable;
	public delegate void OnRageChange(float percentage, GameObject GO);
	public static event OnRageChange onRageChange;

	//substract health
	public void SubstractRage(int damage){
		if(!invulnerable){

			//reduce hp
			CurrentRp = Mathf.Clamp(CurrentRp -= damage, 0, MaxRp);

			//sendupdate Health Event
			SendUpdateEvent();
		}
	}

	//add health
	public void AddRage(int amount){
		CurrentRp = Mathf.Clamp(CurrentRp += amount, 0, MaxRp);
		SendUpdateEvent();
	}

	public void GetRage(int amount){
		CurrentRp = Mathf.Clamp(CurrentRp = amount, 0, MaxRp);
		SendUpdateEvent();
	}


	//health update event
	void SendUpdateEvent(){
		float CurrentRagePercentage = 1f/MaxRp * CurrentRp;
		if(onRageChange != null) onRageChange(CurrentRagePercentage, gameObject);
	}
}
