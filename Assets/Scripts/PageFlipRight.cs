using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageFlipRight : StateMachineBehaviour
{
    private BookController bc;
    private int thisCurrPage;
    private bool hasDisabledRight;
    private bool hasEnabledLeft;
    private Transform t;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bc = animator.gameObject.transform.parent.GetComponentInParent<BookController>();
        thisCurrPage = bc.currPage;
        hasDisabledRight = false;
        hasEnabledLeft = false;
        t = animator.gameObject.transform;

        bc.FlippingRightCount++;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!hasEnabledLeft && t.rotation.y < 0.9f)
        {
            hasEnabledLeft = true;
            if (thisCurrPage - 1 >= 0)
            {
                bc.EnablePage(thisCurrPage - 1, true);
            }
        }

        if (!hasDisabledRight && t.rotation.y < 0.1f)
        {
            hasDisabledRight = true;
            if (thisCurrPage + 1 < bc.animator.Length - 1)
            {
                bc.EnablePage(thisCurrPage + 1, false);
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bc.FlippingRightCount--;

        bc.RevealLevel0Canvas();
    }
}
