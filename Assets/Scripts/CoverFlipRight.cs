using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverFlipRight : StateMachineBehaviour
{
    private BookController ai;
    private int thisCurrPage;



    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ai = animator.gameObject.transform.parent.GetComponentInParent<BookController>();

        thisCurrPage = ai.currPage;

        ai.FlippingRightCount++;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
	
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ai.FlippingRightCount--;

        ai.RevealLevel0Canvas();
    }
}
