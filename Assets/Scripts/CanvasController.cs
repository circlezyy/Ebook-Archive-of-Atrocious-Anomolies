using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class CanvasController: MonoBehaviour
{
    protected CanvasGroup canvasGroup;

    protected readonly float TIME_DELAY_REVEAL_COMPONENTS = 0.2f;
    protected readonly float TIME_DELAY_HIDE_COMPONENTS = 0.2f;

    public GameObject[] baseComponents;
    public GameObject[] layer2Components;

    protected int pageNum;

    public void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        StartCoroutine(WaitAndDo(TIME_DELAY_HIDE_COMPONENTS, DeactivateComponents));
        FindObjectOfType<BookScript>().PageFlipEvent += OnPageFlip;
    }

    protected void OnPageFlip(int newCurrPage, string direction)
    {
        if (newCurrPage == pageNum)
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            StartCoroutine(WaitAndDo(TIME_DELAY_REVEAL_COMPONENTS, ActivateComponents));
        }
        else
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            DisappearAnimations();
            StartCoroutine(WaitAndDo(TIME_DELAY_HIDE_COMPONENTS, DeactivateComponents));
        }
    }

    abstract protected void DisappearAnimations();

    protected void ActivateComponents()
    {
        foreach (GameObject component in baseComponents)
        {
            component.SetActive(true);
            if (component.GetComponent<Animator>() != null)
                component.GetComponent<Animator>().Play("Appear");
        }
    }

    protected void DeactivateComponents()
    {
        foreach (GameObject component in baseComponents)
            component.SetActive(false);
    }

    protected IEnumerator WaitAndDo(float time, Action action)
    {
        yield return new WaitForSeconds(time);
        action();
    }

    protected void OnBaseButtonClick()
    {
        string buttonName = EventSystem.current.currentSelectedGameObject.name;

        foreach (GameObject layer2Component in layer2Components)
        {
            if (layer2Component.name == buttonName)
            {
                layer2Component.SetActive(true);
                BookScript.Instance.SetLayer2Active(true);
                break;
            }
        }
    }

    protected void OnLayer2ButtonClick()
    {
        EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.SetActive(false);
        BookScript.Instance.SetLayer2Active(false);
    }
}