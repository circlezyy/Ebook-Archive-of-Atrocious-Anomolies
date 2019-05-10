using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class CanvasController: MonoBehaviour
{
    public GameObject Darken;
    public GameObject JurogumoTransform;
    protected CanvasGroup canvasGroup;

    protected readonly float TIME_DELAY_REVEAL_COMPONENTS = 0.2f;
    protected readonly float TIME_DELAY_HIDE_COMPONENTS = 0.2f;
    protected readonly float TIME_DELAY_HIDE_COMPONENTS_FAST = 0f;

    public GameObject baseComponentHolder;
    public GameObject baseComponentFastHolder;
    public GameObject layer2ComponentHolder;


    protected List<GameObject> baseComponents;
    protected List<GameObject> baseComponentsFast;
    protected List<GameObject> layer2Components;

    public int pageNum;

    public void Start()
    {
        baseComponents = new List<GameObject>();
        layer2Components = new List<GameObject>();
        baseComponentsFast = new List<GameObject>();

        foreach (Transform child in baseComponentHolder.transform)
            baseComponents.Add(child.gameObject);

        foreach (Transform child in baseComponentFastHolder.transform)
            baseComponentsFast.Add(child.gameObject);

        foreach (Transform child in layer2ComponentHolder.transform)
            layer2Components.Add(child.gameObject);

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
            StartCoroutine(WaitAndDo(TIME_DELAY_HIDE_COMPONENTS_FAST, DeactivateComponentsFast));
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

        foreach (GameObject component in baseComponentsFast)
        {
            component.SetActive(true);
        }
    }

    protected void DeactivateComponentsFast()
    {
        foreach (GameObject component in baseComponentsFast)
            component.SetActive(false);
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

    virtual public void OnBaseButtonClick()
    {
        string buttonName = EventSystem.current.currentSelectedGameObject.name;
        if (Darken != null)
            Darken.SetActive(true);

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

    public void OnJorogumoButtonClicked()
    {
        string buttonName = EventSystem.current.currentSelectedGameObject.name;
        JurogumoTransform.SetActive(true);
    }

    virtual public void OnLayer2ButtonClick()
    {
        if (Darken != null)
            Darken.SetActive(false);
        EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.SetActive(false);
        BookScript.Instance.SetLayer2Active(false);
    }
}