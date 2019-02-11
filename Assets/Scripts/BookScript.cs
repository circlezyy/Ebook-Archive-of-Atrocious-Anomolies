using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class BookScript : MonoBehaviour
{
    private bool isAutoFlipping;
    private int currPage;

    private IUserInput keyboardInput;
    private IUserInput touchInput;
    private IUserInput inputStrategy;

    private readonly float AUTO_FLIP_GAP = 0.2f;

    public delegate void PageEvent(int newCurrPage, string direction);
    public event PageEvent PageFlipEvent;

    public Animator[] animator;

    void Start()
    {
        Application.targetFrameRate = 60;
        currPage = 0;
        keyboardInput = new UserKeyboardInput();
        touchInput = new UserIPadInput();
        inputStrategy = keyboardInput;

        for (int i = 2; i < animator.Length - 1; i++)
        {
            animator[i].Play("Hide");
        }
    }

    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (isAutoFlipping)
            return;

        switch (inputStrategy.GetInput())
        {
            case "left":
                FlipLeft();
                break;
            case "right":
                FlipRight();
                break;
        }
    }

    public void AutoFlip()
    {
        isAutoFlipping = true;

        float autoFlipTime = 0;
        int autoFlipCount = 0;

        switch(EventSystem.current.currentSelectedGameObject.name)
        {
            case "button_wendigo":
                autoFlipCount = 1;
                break;
            case "button_fresnowalker":
                autoFlipCount = 2;
                break;
            case "button_jorogumo":
                autoFlipCount = 3;
                break;
            case "button_leyak":
                autoFlipCount = 4;
                break;
            case "button_lusca":
                autoFlipCount = 5;
                break;
            case "button_nguruvilu":
                autoFlipCount = 6;
                break;
            case "button_nightcrawler":
                autoFlipCount = 7;
                break;
        }

        for (int i = 0; i < autoFlipCount; i++)
            Invoke("FlipLeft", autoFlipTime += AUTO_FLIP_GAP);

        Invoke("TurnOffAutoFlipping", autoFlipTime);
    }

    public void TurnOffAutoFlipping()
    {
        isAutoFlipping = false;
    }



    public void FlipRight()
    {
        if (currPage > 0)
        {
            currPage--;
            animator[currPage].Play("FlipRight");

            if (PageFlipEvent != null)
            {
                PageFlipEvent(currPage, "right");
            }

            if (currPage >= 1 && currPage <= animator.Length - 3)
            {
                StartCoroutine(HideOrRevealPage(currPage + 1, "Hide", 0.3f));
            }

            if (currPage >= 2 && currPage <= animator.Length - 2)
            {
                StartCoroutine(HideOrRevealPage(currPage - 1, "RevealLeft", 0.05f));
            }
        }
    }

    public void FlipLeft()
    {
        if (currPage < animator.Length)
        {
            animator[currPage].Play("FlipLeft");
            currPage++;

            if (PageFlipEvent != null)
            {
                PageFlipEvent(currPage, "left");
            }

            if (currPage >= 3 && currPage <= animator.Length - 1)
            {
                StartCoroutine(HideOrRevealPage(currPage - 2, "Hide", 0.3f));
            }

            if (currPage >= 2 && currPage <= animator.Length - 2)
            {
                StartCoroutine(HideOrRevealPage(currPage, "RevealRight", 0.05f));
            }
        }
    }

    IEnumerator HideOrRevealPage(int page, string animationName, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        animator[page].Play(animationName);
    }
}
