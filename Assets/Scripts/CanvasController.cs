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
    public GameObject wendigo;

    private BookController bc;
    private MapController mc;
    private MapController wc;

    public bool IsCleared { get; private set; }

    /*
     * Called from BookController
     * 
     * The book has stopped flipping
     *    
     * so that the canvas controller can reveal panels 
     */
    public void EnablePanels(int currPage)
    {
        IsCleared = false;

        switch (currPage)
        {
            case 1:
                map.SetActive(true);
                break;
            case 2:
                wendigo.SetActive(true);
                break;
            default:
                break;
        }
    }

    /* Called from BookController
     *    
     * BookController will be flipping left so hide everything
     */
    public void HidePanels(int currPage)
    {
        if (!mc.isActiveAndEnabled && !wc.isActiveAndEnabled)
        {
            IsCleared = true;
        }
        else
        {
            if (mc.isActiveAndEnabled)
                mc.Hide(currPage + 1);

            if (wc.isActiveAndEnabled)
                wc.Hide(currPage + 1);
        }
    }

    /*
     * Called from MapController
     * Called from WendigoController
     * 
     * Notification that they are disabled   
     */
    public void PanelHidden()
    {
        IsCleared = true;
    }

    private void Start()
    {
        bc = book.GetComponent<BookController>();
        mc = map.GetComponent<MapController>();
        wc = wendigo.GetComponent<MapController>();
    }
}