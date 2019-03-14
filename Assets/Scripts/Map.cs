using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Map : CanvasController
{
    private string SelectedIcon;

    new public void Start()
    {
        base.Start();
        pageNum = 1;
        SelectedIcon = "";
    }

    override protected void DisappearAnimations()
    {
        foreach (GameObject component in baseComponents)
        {
            if (component.activeSelf)
            {
                if (SelectedIcon == component.name)
                {
                    component.GetComponent<Animator>().Play("DisappearGrow");
                }
                else
                {
                    component.GetComponent<Animator>().Play("DisappearShrink");
                }
                SelectedIcon = "";
            }
        }
    }

    public void OnIconSelected()
    {
        if (SelectedIcon == "")
        {
            EventSystem.current.currentSelectedGameObject.GetComponent<Animator>().Play("GrowHoldShrink");
            SelectedIcon = EventSystem.current.currentSelectedGameObject.name;
            StartCoroutine(WaitAndDo(0.5f, BookScript.Instance.AutoFlip));
        }
    }
}
