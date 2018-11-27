using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookBase : StateMachineBehaviour
{
    public GameObject book;
    public BookAnimatedAI ai;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        book = animator.gameObject;
        ai = book.GetComponent<BookAnimatedAI>();
    }
}
