using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MenuButtonClicked : MonoBehaviour {

    public GameObject menu;  

    // Use this for initialization
    void Start () {
        
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(Clicked);
    }
	
    void Clicked()
    {
        if (!menu.activeInHierarchy) menu.SetActive(true);                         
        else if (menu.activeInHierarchy) menu.SetActive(false);
    }    
}
