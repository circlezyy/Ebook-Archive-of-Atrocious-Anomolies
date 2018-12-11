using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverFlipLeft : StateMachineBehaviour
{
    private BookController ai;
    private int thisCurrPage;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ai = animator.gameObject.transform.parent.GetComponentInParent<BookController>();

        thisCurrPage = ai.currPage;

        ai.FlippingLeftCount++;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ai.FlippingLeftCount--;

        ai.RevealLevel0Canvas();
    }
}
