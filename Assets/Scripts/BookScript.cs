using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;

public class BookScript : MonoBehaviour
{
    public GameObject JurogumoTransform;
    public VideoPlayer JurogumoVideo;
    public VideoClip human;
    public GameObject TableDarkFilter;
    public GameObject CreditsButton;
    public GameObject ShowCreditsButton;

    public Text dirText;
    public Text dotText;
    public Text dirMagnitudeText;

    private bool isAutoFlipping;
    private int currPage;

    private IUserInput keyboardInput;
    private IUserInput touchInput;
    private IUserInput inputStrategy;

    private readonly float AUTO_FLIP_GAP = 0.2f;
    private readonly float FLIP_LEFT_HIDE_DELAY = 0.3f;
    private readonly float FLIP_RIGHT_HIDE_DELAY = 0.05f;

    public delegate void PageEvent(int newCurrPage, string direction);
    public event PageEvent PageFlipEvent;

    public Animator[] animator;

    public static BookScript Instance;
    private bool isLayer2Active;
    private bool isFlippingLeft;
    private bool isFlippingRight;
    private int leftCount;
    private int rightCount;


    void Start()
    {
        Instance = this;
        Application.targetFrameRate = 60;
        AudioManager.Instance.Play("intro");
        Invoke("PlayLoopDelayed", 43.385f);
        currPage = 0;
        keyboardInput = new UserKeyboardInput();
        touchInput = new UserIPadInput(dirText, dotText, dirMagnitudeText);
        inputStrategy = keyboardInput;

        for (int i = 2; i < animator.Length - 1; i++)
        {
            animator[i].Play("Hide");
        }
    }

    void PlayLoopDelayed()
    {
        AudioManager.Instance.Play("loop");
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
            case "right":
                FlipLeft();
                break;
            case "left":
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

    private void TurnOffAutoFlipping()
    {
        isAutoFlipping = false;
    }

    private void FlipRight()
    {
        JurogumoTransform.SetActive(false);
        JurogumoVideo.clip = human;

        if (isLayer2Active)
            return;


        if (leftCount > 0)
            return;

        if (currPage > 0)
        {
            PlayRandomFlip();

            currPage--;

            if (currPage == 0)
            {
                TableDarkFilter.SetActive(false);
                ShowCreditsButton.SetActive(true);
            }

            animator[currPage].Play("FlipRight");
            rightCount++;

            if (PageFlipEvent != null)
            {
                PageFlipEvent(currPage, "right");
            }

            if (currPage >= 1 && currPage <= animator.Length - 3)
            {
                StartCoroutine(HideOrRevealPage(currPage + 1, "Hide", FLIP_LEFT_HIDE_DELAY));
            }

            if (currPage >= 2 && currPage <= animator.Length - 2)
            {
                StartCoroutine(HideOrRevealPage(currPage - 1, "RevealLeft", FLIP_RIGHT_HIDE_DELAY));
            }
        }
    }

    private void FlipLeft()
    {
        ShowCreditsButton.SetActive(false);
        CreditsButton.SetActive(false);
        JurogumoTransform.SetActive(false);
        JurogumoVideo.clip = human;

        TableDarkFilter.SetActive(true);

        if (isLayer2Active)
            return;

        if (rightCount > 0)
            return;
            
        if (currPage < 7)
        {
            PlayRandomFlip();

            animator[currPage].Play("FlipLeft");
            leftCount++;

            currPage++;

            if (PageFlipEvent != null)
            {
                PageFlipEvent(currPage, "left");
            }

            if (currPage >= 3 && currPage <= animator.Length - 1)
            {
                StartCoroutine(HideOrRevealPage(currPage - 2, "Hide", FLIP_LEFT_HIDE_DELAY));
            }

            if (currPage >= 2 && currPage <= animator.Length - 2)
            {
                StartCoroutine(HideOrRevealPage(currPage, "RevealRight", FLIP_RIGHT_HIDE_DELAY));
            }
        }
    }

    private IEnumerator HideOrRevealPage(int page, string animationName, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        animator[page].Play(animationName);
    }

    public void SetLayer2Active(bool value)
    {
        isLayer2Active = value;
    }

    private void PlayRandomFlip()
    {
        var num = Random.Range(1, 4);
        AudioManager.Instance.PlayOverlapping("flip" + num);
    }

    public void FlipLeftCompleted()
    {
        leftCount--;
        if (leftCount < 0)
            leftCount = 0;
    }

    public void FlipRightCompleted()
    {
        rightCount--;
        if (rightCount < 0)
            rightCount = 0;
    }
}
