using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HatMenuHandler : MonoBehaviour {

	// Use this for initialization
	public GameObject hatMenu;
	public GameObject hatObject;
	public Sprite catInTheHat;
	public Sprite crown;
	public Sprite helicopter;
	public Sprite joker;
	public Sprite pirate;
	public Sprite sheriff;
	public Sprite sombrero;
	public Sprite wizard;
	private Sprite currentHat;
	void Awake () {
		currentHat = helicopter;
		hatObject.GetComponent<SpriteRenderer> ().sprite = currentHat;
	}
	
	// Update is called once per frame
	public void MenuClicked () {
		if (!hatMenu.activeInHierarchy) hatMenu.SetActive(true);                         
        else if (hatMenu.activeInHierarchy) hatMenu.SetActive(false);
	}

	public void SetCatInTheHat() {
		currentHat = catInTheHat;
	}
	public void SetCrown() {
		currentHat = crown;
	}
	public void SetHelicopter() {
		currentHat = helicopter;
	}
	public void SetJoker() {
		currentHat = joker;
	}

	public void SetPirate() {
		currentHat = pirate;
	}
	public void SetSheriff() {
		currentHat = sheriff;
	}
	public void SetSombrero() {
		currentHat = sombrero;
	}
	public void SetWizard() {
		currentHat = wizard;
	}

	void Update(){
		hatObject.GetComponent<SpriteRenderer> ().sprite = currentHat;
	}
}
