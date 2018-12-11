using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject map;
    private MapController mapController; 

    private void Start()
    {
        mapController = map.GetComponent<MapController>();
    }

    /*
     * called by button's animation
     * 
     * tells mapcontroller that a button has disappeared
     * 
     * and disables the button
     */
    public void FinishedAnimation()
    {
        mapController.ButtonsDisappeared();
        gameObject.SetActive(false);
    }
}
