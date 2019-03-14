using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class FresnoWalker : CanvasController
{ 

    new public void Start()
    {
        base.Start();
        pageNum = 3;
    }

    override protected void DisappearAnimations()
    {
        foreach (GameObject component in baseComponents)
        {
            if (component.activeSelf)
                if (component.GetComponent<Animator>() != null)
                    component.GetComponent<Animator>().Play("DisappearShrink");

        }
    }
}
