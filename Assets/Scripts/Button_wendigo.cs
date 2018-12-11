using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button_wendigo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetBool("isHovering", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        animator.SetBool("isHovering", false);
    }
}
