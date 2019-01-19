using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BookController : MonoBehaviour
{
    public GameObject[] page;
    public Animator[] animator;
    public GameObject innerPages;
    public CanvasController canvasController;

    private int DestPage { get; set; }

    public int CurrPage { get; set; }
    public int FlippingLeftCount { get; set; }
    public int FlippingRightCount { get; set; }

    private IUserInput keyboardInput;
    private IUserInput touchInput;
    private IUserInput inputStrategy;

    private float pageTurnTimer;


    /*
     * Called by button that goes to a page
     */
    public void ButtonClickGoToPage(int num)
    {
        DestPage = num;
    }

    /*
     * Called by PageFlipLeft or PageFlipRight
     * 
     * Nofication that a page has finished flipping so book can check
     * if all pages are done so the canvas can be revealed
     */
    public void DoneFlipping()
    {
        if (FlippingLeftCount == 0 && FlippingRightCount == 0)
        {
            canvasController.EnablePanels(CurrPage);
        }
    }

    /*
     * Called by PageFlipLeft or PageFlipRight
     * 
     * Notification that page is about to conceal
     * or reveal another page   
     */
    public void EnablePage(int num, bool isEnable)
    {
        page[num].transform.Find("page").GetComponent<SkinnedMeshRenderer>().enabled = isEnable;
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
        CurrPage = 0;
        keyboardInput = new UserKeyboardInput();
        touchInput = new UserIPadInput();
        inputStrategy = keyboardInput;
        FlippingLeftCount = 0;
        FlippingRightCount = 0;
    }

    private void Update()
    {
        GetInput();
        CheckTurnPage();
    }

    private void CheckTurnPage()
    {
        if (DestPage != CurrPage)
        {
            if (Time.time > pageTurnTimer)
            {
                pageTurnTimer = Time.time + 0.5f;
                if (DestPage > CurrPage)
                    FlipLeftRequest();
                else
                    FlipRightRequest();
            }
        }
    }

    /*
     * 
     */
    private void GetInput()
    {
        switch (inputStrategy.GetInput())
        {
            case "left":
                if (DestPage == CurrPage && CurrPage != page.Length)
                    DestPage = CurrPage + 1;
                FlipLeftRequest();
                break;
            case "right":
                if (DestPage == CurrPage && CurrPage != 0)
                    DestPage = CurrPage - 1;
                FlipRightRequest();
                break;
            default:
                break;
        }
    }

    private void FlipLeftRequest()
    {
        //first check if book animations is ok with page flip
        if (FlippingRightCount == 0 && CurrPage < animator.Length)
        {
            //next check if canvas is cleared
            if (!canvasController.IsCleared)
            {
                canvasController.HidePanels(CurrPage);
            }
            else
            {
                animator[CurrPage++].SetTrigger("flipLeft");
            }
        }
    }

    private void FlipRightRequest()
    {
        if (FlippingLeftCount == 0 && CurrPage > 0)
        {
            if (!canvasController.IsCleared)
                canvasController.HidePanels(CurrPage);
            else
            {
                animator[--CurrPage].SetTrigger("flipRight");
            }
        }
    }
}
