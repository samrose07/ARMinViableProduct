using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HatButtonScript : MonoBehaviour {

    public bool purchased;
    public int price;
    public bool selected;
    public Sprite hat;
    public Text priceText;

    void Start ()
    {
        if (!purchased)
        {
            priceText.text = "Price: " + price.ToString();
        }
        else
        {
            priceText.text = "Unlocked!";
        }
    }
}
