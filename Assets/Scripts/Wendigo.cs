using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Wendigo : CanvasController
{
    new public void Start()
    {
        base.Start();
        pageNum = 2;
    }

    override protected void DisappearAnimations()
    {
        foreach (GameObject component in baseComponents)
        {
            if (component.activeSelf)
            {
                var animator = component.GetComponent<Animator>();
                if (animator)
                    animator.Play("DisappearShrink");
            }
        }
    }
}
