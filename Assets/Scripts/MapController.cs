using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    public GameObject[] subcomponents;
    public GameObject canvas;

    private CanvasController cc;
    private int pageDestination;

    private int hiddenSubcomponentCount;

    public void ButtonClicked_Mushroomnote_wendigo()
    {
        gameObject.transform.Find("Layer2_1").gameObject.SetActive(true);
    }

    public void ButtonClicked_Hoofnote_wendigo()
    {
        gameObject.transform.Find("Layer2_2").gameObject.SetActive(true);
    }

    public void ButtonClicked_Skullnote_wendigo()
    {
        gameObject.transform.Find("Layer2_3").gameObject.SetActive(true);
    }

    public void ButtonClicked_Hide_All_Layer2()
    {
        gameObject.transform.Find("Layer2_1").gameObject.SetActive(false);
        gameObject.transform.Find("Layer2_2").gameObject.SetActive(false);
        gameObject.transform.Find("Layer2_3").gameObject.SetActive(false);
    }

    //public void ButtonClicked

    /* Called by CanvasController
     * 
     * MapController remembers which page to go to
     * 
     * Triggers the disappearing of all buttons
     */
    public void Hide(int num)
    {
        pageDestination = num;
        HideAllSubcomponents();
    }

    /*
     * Called by Button
     * 
     * Occurs when button disappearing animation finishes
     */
    public void SubcomponentHidden()
    {
        hiddenSubcomponentCount++;

        if (hiddenSubcomponentCount == subcomponents.Length)
        {
            cc.PanelHidden();
            gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        cc = canvas.GetComponent<CanvasController>();
    }

    private void OnEnable()
    {
        hiddenSubcomponentCount = 0;
        EnableAllSubcomponents();
    }

    /*
     * Called by this script
     * 
     * Enables all subcomponents
     */
    private void EnableAllSubcomponents()
    {
        foreach (GameObject subcomponent in subcomponents)
        {
            subcomponent.SetActive(true);
        }
    }

    /*
     * Called by this script
     * 
     * Triggers the disappearing animation for all subcomponents
     */
    private void HideAllSubcomponents()
    {
        foreach (GameObject s in subcomponents)
        {
            s.GetComponent<Animator>().SetTrigger("hide");
        }
    }
}
