using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwipeScript : MonoBehaviour {

    private Vector3 FirstTouchPos;   //First touch position
    private Vector3 LastTouchPos;   //Last touch position
    public int ScreenPercentageForSwipe;
    private float dragDistance;  //minimum distance for a swipe to be registered

    public Image Pointer;

    public GameObject Simon;

    public float pointinterval = 1;
    float currenttime = 0;


    void Start()
    {
        dragDistance = Screen.height * ScreenPercentageForSwipe / 100; //dragDistance is N% height of the screen
        
    }

    void Update()
    {
        if (Input.touchCount == 1) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0); // get the touch
            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                FirstTouchPos = touch.position;
                LastTouchPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                LastTouchPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                LastTouchPos = touch.position;  //last touch position. Ommitted if you use list

                //Check if drag distance is greater than N% of the screen height
                //It's a drag
                if (Mathf.Abs(LastTouchPos.x - FirstTouchPos.x) > dragDistance || Mathf.Abs(LastTouchPos.y - FirstTouchPos.y) > dragDistance)
                {
                    //check if the drag is vertical or horizontal
                    if (Mathf.Abs(LastTouchPos.x - FirstTouchPos.x) > Mathf.Abs(LastTouchPos.y - FirstTouchPos.y))
                    {

                        //If the horizontal movement is greater than the vertical movement...
                        if ((LastTouchPos.x > FirstTouchPos.x))  //If the movement was to the right)
                        {
                            //Right swipe
                            if (Simon.GetComponent<SimonDance>().PlayerTurn)
                            {
                                Pointer.transform.rotation = Quaternion.Euler(0,0,-90);
                                Pointer.enabled = true;
                                currenttime = 0;

                                Simon.GetComponent<SimonDance>().PlayerMoved = SimonDance.Moves.MoveUp;
                                Simon.GetComponent<SimonDance>().Moved = true;
                            }
                        }
                        else
                        {
                            //Left swipe
                            if (Simon.GetComponent<SimonDance>().PlayerTurn)
                            {
                                Pointer.transform.rotation = Quaternion.Euler(0, 0, 90);
                                Pointer.enabled = true;
                                currenttime = 0;

                                Simon.GetComponent<SimonDance>().PlayerMoved = SimonDance.Moves.MoveLeft;
                                Simon.GetComponent<SimonDance>().Moved = true;
                            }
                        }
                    }
                    else
                    {
                        //the vertical movement is greater than the horizontal movement
                        if (LastTouchPos.y > FirstTouchPos.y)  //If the movement was up
                        {
                            //Up swipe
                            if (Simon.GetComponent<SimonDance>().PlayerTurn)
                            {
                                Pointer.transform.rotation = Quaternion.Euler(0, 0, 0);
                                Pointer.enabled = true;
                                currenttime = 0;

                                Simon.GetComponent<SimonDance>().PlayerMoved = SimonDance.Moves.MoveUp;
                                Simon.GetComponent<SimonDance>().Moved = true;
                            }
                        }
                        else
                        {
                            //Down swipe
                            if (Simon.GetComponent<SimonDance>().PlayerTurn)
                            {
                                Pointer.transform.rotation = Quaternion.Euler(0, 0, 180);
                                Pointer.enabled = true;
                                currenttime = 0;                                

                                Simon.GetComponent<SimonDance>().PlayerMoved = SimonDance.Moves.MoveDown;
                                Simon.GetComponent<SimonDance>().Moved = true;
                            }
                        }
                    }
                }
                else
                {
                    //It's a tap as the drag distance is less than N% of the screen height          

                    if (Simon.GetComponent<SimonDance>().Over)
                    {
                        SceneManager.LoadScene("Menu");

                    }

                    if(!Simon.GetComponent<SimonDance>().Ready)
                    {
                        Simon.GetComponent<SimonDance>().Ready = true;
                        StartCoroutine(Simon.GetComponent<SimonDance>().Dance());
                    }
                }
            }
        }

        if(Pointer.enabled)
        {
            
            currenttime += Time.deltaTime;
            Debug.Log(currenttime.ToString());
            if (currenttime >= pointinterval)
            {
                Pointer.enabled = false;
            }
        }

    }
}
