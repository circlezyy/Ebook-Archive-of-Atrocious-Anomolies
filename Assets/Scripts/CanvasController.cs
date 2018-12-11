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

    public void FlippingRight(string currPage)
    {
        map.SetActive(false);
    }

    public void FlippingLeft(string currPage)
    {
        map.SetActive(false);
    }

    public void AllAnimationsOnPageAreDoneSoGoToThisPage(int pageDestination)
    {
        bc.FlipLeftToPage(pageDestination);
    }

    private void Start()
    {
        bc = book.GetComponent<BookController>();
    }
}