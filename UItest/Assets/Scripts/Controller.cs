using System;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using UnityEngine.UI;
public class Controller : MonoBehaviour {

    public Visualizer visPrefab;

    public GameObject scanOverlay;
    private Dictionary<int, Visualizer> visualizers = new Dictionary<int, Visualizer>();
    private List<AugmentedImage> augImages = new List<AugmentedImage>();
    public Text distanceText;
    //for points
    public Text settingText;
    public Text pointsText;
    public int points = 0;
    public int count = 0;
    public HatMenuHandler hatMenu;
    public Button strangerBtn;
    public Button familyBtn;
    public Button friendBtn;
    public string currentSetting = "Friend";
    public float camToMarkDist;
    Visualizer vis = null;
    private void Awake()
    {
        Application.targetFrameRate = 60;
        settingText.text = currentSetting;
    }
    //set to current setting
    public void SpaceSetting(string selectedSetting)
    {
        currentSetting = selectedSetting;
        settingText.text = selectedSetting;
    }

    public void updateSprite(Sprite sprite)
    {
        vis.GetComponent<SpriteRenderer>().sprite = sprite;
    }
    // Update is called once per frame
    void Update () {

        //check if back 
        if (Input.GetKey(KeyCode.Escape)) Application.Quit();

        //keep screen on if tracking
        if (Session.Status != SessionStatus.Tracking) Screen.sleepTimeout = SleepTimeout.SystemSetting;
        else Screen.sleepTimeout = SleepTimeout.NeverSleep;

        //get the images
        Session.GetTrackables<AugmentedImage>(augImages, TrackableQueryFilter.Updated);

        //start tracking
        foreach(var image in augImages)
        {
            
            visualizers.TryGetValue(image.DatabaseIndex, out vis);
            if(image.TrackingState == TrackingState.Tracking && vis == null)
            {
                Anchor anchor = image.CreateAnchor(image.CenterPose);
                vis = (Visualizer)Instantiate(visPrefab, anchor.transform);
                vis.Image = image;
                visualizers.Add(image.DatabaseIndex, vis);
                
            }
            else if(image.TrackingState == TrackingState.Stopped && vis != null)
            {
                visualizers.Remove(image.DatabaseIndex);
                GameObject.Destroy(vis.gameObject);
            }
            //finish below for distance. Currently just getting image tracking done
            if(image.TrackingState == TrackingState.Tracking)
            {
                Anchor anchor = image.CreateAnchor(image.CenterPose);
                Vector3 anchorLoc = new Vector3(anchor.transform.position.x, anchor.transform.position.y, anchor.transform.position.z);
                camToMarkDist = Vector3.Distance(anchorLoc, Camera.main.transform.position);
                if(vis != null)
                {
                    //based on https://sites.google.com/site/newmedianewtechnology2016/portfolios/matthijs-h/lab-3-private-space-visualizer
                    //that model, emulating the "social space." if selected for further development we should implement
                    //the other spaces as well as a way to choose what you are testing
                    switch(currentSetting)
                    {
                        case "Family":
                            if (camToMarkDist >= .45 && camToMarkDist < 1.2)
                            {
                                // vis.SwitchOnOff(true);
                                count++;
                                if (count >= 60)
                                {
                                    points += 10;
                                    count = 0;
                                }

                                pointsText.text = "Points: " + points;
                                vis.SwitchOnOff(true);
                            }
                            else
                            {
                                vis.SwitchOnOff(false);
                            }
                            break;
                        case "Friend":
                            if (camToMarkDist >= 1.2 && camToMarkDist < 3.7)
                            {
                                // vis.SwitchOnOff(true);
                                count++;
                                if (count >= 60)
                                {
                                    points += 10;
                                    count = 0;
                                }

                                pointsText.text = "Points: " + points;
                                vis.SwitchOnOff(true);
                            }
                            else
                            {
                                vis.SwitchOnOff(false);
                            }
                            break;
                        case "Stranger":
                            if (camToMarkDist >= 3.7 && camToMarkDist < 7.6)
                            {
                                // vis.SwitchOnOff(true);
                                count++;
                                if (count >= 60)
                                {
                                    points += 10;
                                    count = 0;
                                }

                                pointsText.text = "Points: " + points;
                                vis.SwitchOnOff(true);
                            }
                            else
                            {
                                vis.SwitchOnOff(false);
                            }
                            break;
                    }
                }
                distanceText.text = "Current Distance: " + camToMarkDist.ToString("F2") + "m";
            }


        }
        //show overlay if not tracking an image
        foreach(var visualizer in visualizers.Values)
        {
            if (visualizer.Image.TrackingState == TrackingState.Tracking)
            {
                scanOverlay.SetActive(false);
                return;
            }
        }
        
        scanOverlay.SetActive(true);

    }

    bool setCount(bool act)
    {
        return true;
    }
    bool stopCount(bool act)
    {
        return false;
    }
   
}
