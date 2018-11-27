using UnityEngine;

public class BookAnimatedAI : MonoBehaviour
{
    private IUserInput keyboardInput;
    private IUserInput touchInput;
    private IUserInput inputStrategy;

    public GameObject[] page;

    public Animator[] animator;

    public int currPage;

	void Start ()
    {
        Application.targetFrameRate = 60;
        currPage = 0;
        keyboardInput = new UserKeyboardInput();
        touchInput = new UserIPadInput();
        inputStrategy = touchInput; //keyboardInput;
	}
	
	void Update ()
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
        if (currPage < animator.Length)
        {
            animator[currPage].Play("flipLeft");
            currPage++;
        }
    }

    private void FlipRight()
    {
        if (currPage > 0)
        {
            currPage--;
            animator[currPage].Play("flipRight");
        }
    }
}
