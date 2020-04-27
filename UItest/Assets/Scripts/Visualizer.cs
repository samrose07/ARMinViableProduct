using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using GoogleARCoreInternal;
using UnityEngine.UI;
public class Visualizer : MonoBehaviour {

    //to visualize
    public AugmentedImage Image;
    public Text visText;
    //use to place
    public GameObject hat;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //if not tracking make sure hat invis. if tracking, vis.
        /*
         * if(Image == null || Image.TrackingState != TrackingState.Tracking)
        {
            hat.SetActive(false);
            return;
        }*/
        float width = Image.ExtentX /2;
        float height = Image.ExtentZ/2;
        hat.transform.localPosition = Vector3.zero;
        //hat.SetActive(true);

        visText.text = "ive arrived here.";
        
	}
    //if it gets passed the "true" then it turns it on. if not, turns off
    public void SwitchOnOff(bool on)
    {
        if (on)
        {
            hat.SetActive(true);
        }
        if(!on)
        {
            hat.SetActive(false);
        }
    }
    public bool CheckOn()
    {
        if(hat.activeInHierarchy)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
