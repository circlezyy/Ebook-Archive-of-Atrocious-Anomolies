using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    public GameObject[] subcomponents;
    public Animator[] buttonAnimators;
    public GameObject book;
    public GameObject canvas;

    private BookController bc;
    private CanvasController cc;
    private int pageDestination;

    private int disabledSubComponentsCount;

    /*
     * 
     * MapController remembers which page to go to
     * 
     * Triggers the disappearing of all buttons
     */
    public void FlipRequest(int num)
    {
        pageDestination = num;
        HideSubcomponents();
    }

    /*
     * Called when button disappearing animation finishes
     */
    public void ButtonsDisappeared()
    {
        disabledSubComponentsCount++;

        if (disabledSubComponentsCount == buttonAnimators.Length)
        {
            cc.AllAnimationsOnPageAreDoneSoGoToThisPage(pageDestination);
            gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        bc = book.GetComponent<BookController>();
        cc = canvas.GetComponent<CanvasController>();
    }

    private void OnEnable()
    {
        disabledSubComponentsCount = 0;
        EnableAllSubcomponents();
    }

    /*
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
     * Triggers the disappearing animation for all subcomponents
     */
    private void HideSubcomponents()
    {
        foreach (Animator animator in buttonAnimators)
        {
            animator.SetTrigger("hide");
        }
    }
}
