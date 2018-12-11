using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * 1. Holds a reference to all animation panels
 * 
 * 2. Enables and disables all animation panels
 * 
 * 
 */
public class CanvasController: MonoBehaviour
{
    public GameObject book;
    public GameObject map;

    private BookController bc;
    private MapController mc;
    
    /*
     * This function is called from the BookAnimatedAI when it is not flipping
     * so that the canvas controller can reveal the correct animation panels   
     */
    public void NoFlipping(string currPage)
    {
        switch (currPage)
        {
            case "1":
                map.SetActive(true);
                break;
            default:
                break;
        }
    }

    /* Called from BookController
     *   
     * BookController will be flipping right so hide everything
     */
    public void FlippingRightRequested(int currPage)
    {
        if (mc.isActiveAndEnabled)
            mc.FlipRequest(currPage - 1);
        else
            AllAnimationsOnPageAreDoneSoGoToThisPage(currPage - 1);
    }

    /* Called from BookController
     *    
     * BookController will be flipping left so hide everything
     */
    public void FlippingLeftRequested(int currPage)
    {
        if (mc.isActiveAndEnabled)
            mc.FlipRequest(currPage + 1);
        else
        {
            AllAnimationsOnPageAreDoneSoGoToThisPage(currPage + 1);
        }
    }

    public void AllAnimationsOnPageAreDoneSoGoToThisPage(int pageDestination)
    {
        if (bc.currPage < pageDestination)
            bc.FlipLeftToPage(pageDestination);
        else if (bc.currPage > pageDestination)
            bc.FlipRightToPage(pageDestination);
        else
            Debug.Log("error");
    }

    private void Start()
    {
        bc = book.GetComponent<BookController>();
        mc = map.GetComponent<MapController>();
    }
}