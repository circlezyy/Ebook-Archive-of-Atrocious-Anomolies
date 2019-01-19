using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookController3 : MonoBehaviour
{
    private int currPage;
    private Animator bookAnimator;
    private Animation[] bookAnimation;

    public Animator twoThreeAnimator;



    private IUserInput keyboardInput;
    private IUserInput touchInput;
    private IUserInput inputStrategy;

    private void Start()
    {
        Application.targetFrameRate = 60;
        keyboardInput = new UserKeyboardInput();
        touchInput = new UserIPadInput();
        inputStrategy = keyboardInput;

        bookAnimator = GetComponent<Animator>();

        currPage = 0;

        bookAnimation[0] = GetComponent<Animation>();

        //GetComponent<Animator>().runtimeAnimatorController.animationClips["frontFlip"].speed = 0;
        //GetComponent<Animator>().runtimeAnimatorController.animationClips[0].
        //GetComponent<Animation>()["Page1Flip"].speed = 0;
        //GetComponent<Animation>()["Page2Flip"].speed = 0;
    }

    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        switch (inputStrategy.GetInput())
        {
            case "left":
                switch(currPage)
                {
                    case 0:
                        bookAnimation.
                        bookAnimator.speed = 1;
                        bookAnimator.SetBool("FrontLeft", true);
                        twoThreeAnimator.SetTrigger("activate");
                        break;
                    case 1:
                        bookAnimator.SetBool("Page1Left", true);
                        twoThreeAnimator.SetTrigger("deactivate");
                        break;
                    default:
                        Debug.LogError("error");
                        break;
                }
            
                currPage++;
                break;
            case "right":
                switch (currPage)
                {
                    case 1:
                        bookAnimator.SetBool("FrontLeft", false);
                        twoThreeAnimator.SetTrigger("deactivate");
                        break;
                    case 2:
                        bookAnimator.SetBool("Page1Left", false);
                        twoThreeAnimator.SetTrigger("activate");
                        break;
                    default:
                        Debug.LogError("error");
                        break;
                }
                currPage--;
                break;
            default:
                break;
        }
    }
}
