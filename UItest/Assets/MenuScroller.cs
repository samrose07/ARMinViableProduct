using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuScroller : MonoBehaviour {


    private float deltaX, deltaY;
    private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        GameObject menu = GameObject.Find("menuScroller");
        menu.SetActive(false);
	}
 
    // Update is called once per frame
    void Update () {
        if(isActiveAndEnabled)
        {
            
            GameObject menu = GameObject.Find("menuScroller");
            
            if (Input.touchCount > 0)
            {
                
                Touch touch = Input.GetTouch(0);
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        print("drag start");
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;

                        break;
                    case TouchPhase.Moved:
                        print("dragging");
                       // rb.WakeUp();
                            rb.position -= new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);
                        //rb.MovePosition(new Vector2(transform.position.x, touchPos.y - deltaY));
                        
                        break;
                    case TouchPhase.Ended:
                        print("drag end");
                        rb.velocity = Vector2.zero;
                        break;
                }
            }
        }
		
	}
}
