using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class AudioTest : MonoBehaviour
{

    public AudioSource aSource;
    public AudioClip audio1;
    public AudioClip audio2;
    public AudioClip audio3;
    public AudioClip audio4;
    public AudioClip audio5;
    public AudioClip audio6;
    public AudioClip audio7;
    public Text txt;
    private Touch touch;
    private bool canTouch = false;
    public Texture img;
    public Texture img2;
    public Texture img3;
    public Texture img4;
    public Texture img5;
    public Texture img6;
    public Texture img7;
    public RawImage holder;
    public GameObject mnuBtn;
    Texture currentImg;
    public GameObject first;
    public GameObject second;
    void Start()
    {
        //getting the audio component, playing first clip and changing text
        //setting image texture and current image for later use
        aSource = GetComponent<AudioSource>();
        aSource.PlayOneShot(audio1);
        txt.text = "Personal space is the amount of space people need to feel comfortable.";
        holder.texture = img;
        currentImg = img;
    }

    void Update()
    {     
        //checks to see if a clip is playing. If not, then you can touch the 
        //screen to move on to the next slide. Passes on
        //what is playing and what the current image is.
        if (!aSource.isPlaying)
        {            
            canTouch = true;
            PlayNext(aSource, currentImg);
        }
    }

    void PlayNext(AudioSource aS, Texture cI)
    {
        /*
         * These if statements check what the current image is
         * and then set the image to the next one while playing the next
         * audio clip. The text is also changed to reflect
         * the audio clip. canTouch is then set to false so we
         * cannot skip the current slide. This way any accidental
         * touches of the screen during listening do not make the
         * user miss any important information. I created a duplicate
         * set of if-statements below this because unity handles
         * phone touches and mouseclicks as two separate entities.
         * we can remove the mouse clicks when the final version is
         * finished.
         * 
         */
        if (canTouch)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (cI == img)
                {
                    holder.texture = img2;
                    currentImg = img2;
                    aS.PlayOneShot(audio2);
                    txt.text = "If you enter someone's personal space, it can make them feel uncomfortable.";
                    canTouch = false;
                }
                else if (cI == img2)
                {
                    holder.texture = img3;
                    currentImg = img3;
                    aS.PlayOneShot(audio3);
                    txt.text = "So how do we know what distance we should stand away from someone?";
                    canTouch = false;
                }
                else if (cI == img3)
                {
                    holder.texture = img4;
                    currentImg = img4;
                    aS.PlayOneShot(audio4);
                    txt.text = "It can be tricky. Everybody has different amounts of personal space preferences.";
                    canTouch = false;
                }
                else if (cI == img4)
                {
                    holder.texture = img5;
                    currentImg = img5;
                    aS.PlayOneShot(audio5);
                    txt.text = "But a general rule is to keep an arms distance away. ";
                    canTouch = false;
                }
                else if (cI == img5)
                {
                    holder.texture = img6;
                    currentImg = img6;
                    aS.PlayOneShot(audio6);
                    txt.text = "Use this app to practice keeping that distance.";
                    canTouch = false;
                }
                else if (cI == img6)
                {
                    holder.texture = img7;
                    currentImg = img7;
                    aS.PlayOneShot(audio7);
                    txt.text = "And unlock some fun hats along the way!";
                    canTouch = false;
                }
                else if (cI == img7)
                {
                    holder.texture = null;
                    currentImg = null;
                    txt.text = "Start Augmentation here!";
                    //mnuBtn.SetActive(true);
                    SceneManager.LoadScene(sceneName: "ARScene");
                    SceneManager.UnloadSceneAsync(sceneName: "aud");
                    
                }               
            }
            //this is for the touches.
            foreach (Touch touch in Input.touches)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    if (cI == img)
                    {
                        holder.texture = img2;
                        currentImg = img2;
                        aS.PlayOneShot(audio2);
                        txt.text = "If you enter someone's personal space, it can make them feel uncomfortable.";
                        canTouch = false;
                    }
                    else if (cI == img2)
                    {
                        holder.texture = img3;
                        currentImg = img3;
                        aS.PlayOneShot(audio3);
                        txt.text = "So how do we know what distance we should stand away from someone?";
                        canTouch = false;
                    }
                    else if (cI == img3)
                    {
                        holder.texture = img4;
                        currentImg = img4;
                        aS.PlayOneShot(audio4);
                        txt.text = "It can be tricky. Everybody has different amounts of personal space preferences.";
                        canTouch = false;
                    }
                    else if (cI == img4)
                    {
                        holder.texture = img5;
                        currentImg = img5;
                        aS.PlayOneShot(audio5);
                        txt.text = "But a general rule is to keep an arms distance away. ";
                        canTouch = false;
                    }
                    else if (cI == img5)
                    {
                        holder.texture = img6;
                        currentImg = img6;
                        aS.PlayOneShot(audio6);
                        txt.text = "Use this app to practice keeping that distance.";
                        canTouch = false;
                    }
                    else if (cI == img6)
                    {
                        holder.texture = img7;
                        currentImg = img7;
                        aS.PlayOneShot(audio7);
                        txt.text = "And unlock some fun hats along the way!";
                        canTouch = false;
                    }
                    else if (cI == img7)
                    {
                        holder.texture = null;
                        currentImg = null;
                        txt.text = "Start Augmentation here!";
                        //mnuBtn.SetActive(true);
                         SceneManager.LoadScene(sceneName:"ARScene");
                        SceneManager.UnloadSceneAsync(sceneName: "aud");
                       
                    }
                }
            }
        }


    }
}
