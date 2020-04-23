using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HatMenuHandler : MonoBehaviour {

	// Use this for initialization
	public GameObject hatMenu;
	void Start () {
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(MenuClicked);
	}
	
	// Update is called once per frame
	void MenuClicked () {
		if (!hatMenu.activeInHierarchy) hatMenu.SetActive(true);                         
        else if (hatMenu.activeInHierarchy) hatMenu.SetActive(false);
	}
}
