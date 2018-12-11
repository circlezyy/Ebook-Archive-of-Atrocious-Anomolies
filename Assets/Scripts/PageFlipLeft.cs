using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageFlipLeft : StateMachineBehaviour
{
    private BookController bc;
    private int thisCurrPage;
    private bool hasDisabledLeft;
    private bool hasEnabledRight;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bc = animator.gameObject.transform.parent.GetComponentInParent<BookController>();
        thisCurrPage = bc.currPage;
        hasDisabledLeft = false;
        hasEnabledRight = false;

        bc.FlippingLeftCount++;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!hasEnabledRight && animator.gameObject.transform.rotation.y > 0.1f)
        {
            hasEnabledRight = true;
            if (thisCurrPage < bc.animator.Length)
            {
                bc.EnablePage(thisCurrPage, true);
            }
        }

        if (!hasDisabledLeft && animator.gameObject.transform.rotation.y > 0.9f)
        {
            hasDisabledLeft = true;
            if (thisCurrPage - 2 >= 1)
            {
                Debug.Log("disabled page " + (thisCurrPage - 2).ToString());
                bc.EnablePage(thisCurrPage - 2, false);
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bc.FlippingLeftCount--;

        bc.RevealLevel0Canvas();
    }
}
