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
	void Start () {
		//Button btn = GetComponent<Button>();
		//btn.onClick.AddListener(MenuClicked);
	}
	
	// Update is called once per frame
	public void MenuClicked () {
		if (!hatMenu.activeInHierarchy) hatMenu.SetActive(true);                         
        else if (hatMenu.activeInHierarchy) hatMenu.SetActive(false);
	}

	public void SetCatInTheHat() {
		hatObject.GetComponent<SpriteRenderer> ().sprite = catInTheHat;
	}
	public void SetCrown() {
		hatObject.GetComponent<SpriteRenderer> ().sprite = crown;
	}
	public void SetHelicopter() {
		hatObject.GetComponent<SpriteRenderer> ().sprite = helicopter;
	}
	public void SetJoker() {
		hatObject.GetComponent<SpriteRenderer> ().sprite = joker;
	}

	public void SetPirate() {
		hatObject.GetComponent<SpriteRenderer> ().sprite = pirate;
	}
	public void SetSheriff() {
		hatObject.GetComponent<SpriteRenderer> ().sprite = sheriff;
	}
	public void SetSombrero() {
		hatObject.GetComponent<SpriteRenderer> ().sprite = sombrero;
	}
	public void SetWizard() {
		hatObject.GetComponent<SpriteRenderer> ().sprite = wizard;
	}
}
