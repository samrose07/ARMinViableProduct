using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioTest : MonoBehaviour
{

    public AudioSource aSource;
    public Text txt;
    private int count = 1;
    private Touch touch;
    private bool canTouch = false;
    public Texture img;
    public Texture img2;
    public Texture img3;
    public RawImage holder;
    Texture2D myTexture;
    Texture currentImg;

    void Start()
    {

        aSource = GetComponent<AudioSource>();
        txt.text = aSource.clip.length.ToString();
        holder.texture = img;
        currentImg = img;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (aSource.isPlaying)
        {
            txt.text = "playing";

        }
        else
        {
            txt.text = "notPlaying";
            canTouch = true;

            PlayNext(aSource, currentImg);
        }
        //print(currentImg);
    }

    void PlayNext(AudioSource aS, Texture cI)
    {
        if (canTouch)
        {
            if (Input.GetMouseButtonDown(0))
            {
                count += 1;

                if (cI == img)
                {
                    holder.texture = img2;
                    currentImg = img2;
                    aS.Play();
                    canTouch = false;
                }
                else if (cI == img2)
                {
                    holder.texture = img3;
                    currentImg = img3;
                    aS.Play();
                    canTouch = false;
                }
                else if (cI == img3)
                {
                    holder.texture = null;
                    currentImg = null;
                }
                
                
            }
            foreach (Touch touch in Input.touches)
            {

                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {


                    if (cI == img)
                    {
                        holder.texture = img2;
                        currentImg = img2;
                        aS.Play();
                        canTouch = false;
                    }
                    else if (cI == img2)
                    {
                        holder.texture = img3;
                        currentImg = img3;
                        aS.Play();
                        canTouch = false;
                    }
                    else if (cI == img3)
                    {
                        holder.texture = null;
                        currentImg = null;
                    }
                }
            }
        }


    }
}
