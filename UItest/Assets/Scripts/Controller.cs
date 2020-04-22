using System.Collections;
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


    private void Awake()
    {
        Application.targetFrameRate = 60;
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
            Visualizer vis = null;
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
                float camToMarkDist = Vector3.Distance(anchorLoc, Camera.main.transform.position);
                distanceText.text = camToMarkDist.ToString();
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
   
}
