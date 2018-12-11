using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BookController : MonoBehaviour
{
    public GameObject[] page;
    public Animator[] animator;

    public GameObject innerPages;
    public int currPage;
    public int FlippingLeftCount { get; set; }
    public int FlippingRightCount { get; set; }

    public CanvasController canvasController;

    private IUserInput keyboardInput;
    private IUserInput touchInput;
    private IUserInput inputStrategy;

    public void FlipLeftToPage(int targetPage)
    {
        StartCoroutine("IE_FlipLeftToPage", targetPage);
    }

    private IEnumerator IE_FlipLeftToPage(int targetPage)
    {
        while (currPage < targetPage)
        {
            FlipLeft();
            yield return new WaitForSeconds(0.25f);
        }
    }

    public void RevealLevel0Canvas()
    {
        if (FlippingLeftCount == 0 && FlippingRightCount == 0)
        {
            canvasController.NoFlipping(currPage.ToString());
        }
    }

    public void EnablePage(int num, bool isEnable)
    {
        page[num].transform.Find("page").GetComponent<SkinnedMeshRenderer>().enabled = isEnable; //SetActive(isEnable);
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
        currPage = 0;
        keyboardInput = new UserKeyboardInput();
        touchInput = new UserIPadInput();
        inputStrategy = keyboardInput;
        FlippingLeftCount = 0;
        FlippingRightCount = 0;
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        switch (inputStrategy.GetInput())
        {
            case "left":
                FlipLeft();
                break;
            case "right":
                FlipRight();
                break;
            default:
                break;
        }
    }

    private void FlipLeft()
    {
        if (FlippingRightCount == 0 && currPage < animator.Length)
        {
            canvasController.FlippingLeft(currPage.ToString());
            animator[currPage++].SetTrigger("flipLeft");
        }
    }

    private void FlipRight()
    {
        if (FlippingLeftCount == 0 && currPage > 0)
        {
            canvasController.FlippingRight(currPage.ToString());
            animator[--currPage].SetTrigger("flipRight");
        }
    }
}
