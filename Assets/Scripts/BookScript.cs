using UnityEngine;

public class BookScript : MonoBehaviour
{
    private bool canInput;

    private int currPage;

    private IUserInput keyboardInput;
    private IUserInput touchInput;
    private IUserInput inputStrategy;

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
    }

    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
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

    public void FlipRight()
    {
        if (currPage > 0)
        {
            currPage--;
            animator[currPage].Play("FlipRight");
            if (PageFlipEvent != null)
                PageFlipEvent(currPage, "right");

        }
    }

    public void FlipLeft()
    {
        if (currPage < animator.Length)
        {
            animator[currPage].Play("FlipLeft");
            currPage++;
            if (PageFlipEvent != null)
                PageFlipEvent(currPage, "left");
        }
    }
}
