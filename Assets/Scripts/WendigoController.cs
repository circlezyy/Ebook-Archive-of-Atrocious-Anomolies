using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WendigoController : MonoBehaviour
{
    public GameObject[] subcomponents;
    public GameObject canvas;

    private CanvasController cc;
    private int pageDestination;

    private int hiddenSubcomponentCount;


    public void Hide(int num)
    {
        pageDestination = num;
        HideSubcomponents();
    }

    /*
     * Called when button disappearing animation finishes
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

    private void Start ()
    {
        cc = canvas.GetComponent<CanvasController>();
    }

    private void EnableAllSubcomponents()
    {
        foreach (GameObject subcomponent in subcomponents)
        {
            subcomponent.SetActive(true);
        }
    }

    private void HideSubcomponents()
    {
        foreach (GameObject s in subcomponents)
        {
            s.GetComponent<Animator>().SetTrigger("hide");
        }
    }
}
