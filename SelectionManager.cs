using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SelectionManager : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)//# of fingers on the screen
        {
            var touch = Input.GetTouch(0); //first touch
            if (touch.phase == TouchPhase.Began)//if a touch happens
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(touch.position);//camera is the point to start ray

                if (Physics.Raycast(ray, out hit, 200))//raycast to hit an object
                {
                    
                    GameObject[] anchors = GameObject.FindGameObjectsWithTag("Anchor"); //Finding image anchors in the scene
                    foreach (GameObject g in anchors) //cycling through image anchors
                    {
                        ImageAnchor anchor = g.GetComponent<ImageAnchor>(); //getting script off image anchor
                        if (hit.transform.name == anchor.select.name)//chacking what anchor was tapped
                        {
                            //do something if the correct object was tapped
                        }
                        else
                        {
                           //do something if this is not the item tapped
                        }
                    }
                }

            }
        }
    }
}