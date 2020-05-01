using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HatMenuHandler : MonoBehaviour
{

    // Use this for initialization
    public GameObject hatMenu;
    public GameObject hatButtons;
    public GameObject hatObject;
    public Sprite currentHat;
    public Controller controller;
    public Color hatSelectedColor;
    public Button selectedButton;
    public Button purchaseButton;

    void Awake()
    {
        hatObject.GetComponent<SpriteRenderer>().sprite = currentHat;
    }

    public void SelectedHat(Button button)
    {
        HatButtonScript script = button.GetComponent<HatButtonScript>();
        if (script.purchased)
        {
            foreach (Transform child in hatButtons.transform)
            {
                child.GetComponent<Button>().interactable = true;
            }

            button.interactable = false;
            currentHat = script.hat;
        }
        else
        {
            foreach (Transform child in hatButtons.transform)
            {
                child.GetComponent<HatButtonScript>().selected = false;
                child.GetComponent<Image>().color = Color.white;
            }

            script.selected = true;
            button.GetComponent<Image>().color = hatSelectedColor;
            selectedButton = button;
            purchaseButton.interactable = true;
        }
    }

    public void PurchaseHat()
    {
        if (selectedButton)
        {
            HatButtonScript script = selectedButton.GetComponent<HatButtonScript>();

            if (Controller.Instance.points >= script.price)
            {
                Controller.Instance.points -= script.price;
                Controller.Instance.pointsText.text = "Points: " + Controller.Instance.points;

                script.purchased = true;
                script.selected = false;
                selectedButton.GetComponent<Image>().color = Color.white;
                SelectedHat(selectedButton);
                selectedButton = null;
                purchaseButton.interactable = false;
            }
        }
    }

    // Update is called once per frame
    public void MenuClicked()
    {
        if (!hatMenu.activeInHierarchy) hatMenu.SetActive(true);
        else if (hatMenu.activeInHierarchy) hatMenu.SetActive(false);
    }

    void Update()
    {
        hatObject.GetComponent<SpriteRenderer>().sprite = currentHat;
        controller.updateSprite(currentHat);
    }
}
