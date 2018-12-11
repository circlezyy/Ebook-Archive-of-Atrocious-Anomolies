using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    public GameObject[] buttons;
    public Animator[] buttonAnimators;
    public GameObject book;
    public GameObject canvas;

    private BookController bc;
    private CanvasController cc;
    private int pageDestination;

    private int disabledButtonsCount;

    /*
     * Called by a specific button click
     * 
     * MapController remembers which page to go to
     * 
     * Triggers the disappearing of all buttons
     */
    public void MapButtonClick(int num)
    {
        pageDestination = num;
        TellAllButtonsToDisappear();
    }

    /*
     * Called when button disappearing animation finishes
     */
    public void ButtonsDisappeared()
    {
        disabledButtonsCount++;
        if (disabledButtonsCount == buttonAnimators.Length)
        {
            //send message to CanvasController that it can turn the page
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
        disabledButtonsCount = 0;
    }

    /*
     * Enables all buttons
     */
    private void EnableAllButtons()
    {
        foreach (GameObject button in buttons)
        {
            button.SetActive(true);
        }
    }

    /*
     * Triggers the disappearing animation for all buttons
     */
    private void TellAllButtonsToDisappear()
    {
        foreach (Animator animator in buttonAnimators)
        {
            animator.SetTrigger("disappear");
        }
    }
}
