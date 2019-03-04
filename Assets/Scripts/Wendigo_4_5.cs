using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Wendigo_4_5 : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    public GameObject[] baseComponents;
    public GameObject[] layer2Components;

    protected readonly float TIME_DELAY_REVEAL_COMPONENTS = 0.2f;
    protected readonly float TIME_DELAY_HIDE_COMPONENTS = 0.2f;

    public void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        StartCoroutine(WaitAndDo(TIME_DELAY_HIDE_COMPONENTS, DeactivateComponents));

        FindObjectOfType<BookScript>().PageFlipEvent += OnPageFlip;
    }

    public void OnPageFlip(int newCurrPage, string direction)
    {
        if (newCurrPage == 2)
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

    private void ActivateComponents()
    {
        foreach (GameObject component in baseComponents)
        {
            component.SetActive(true);
            component.GetComponent<Animator>().Play("Appear");
        }
    }

    private void DeactivateComponents()
    {
        foreach (GameObject component in baseComponents)
            component.SetActive(false);
    }

    protected void DisappearAnimations()
    {
        foreach (GameObject component in baseComponents)
        {
            if (component.activeSelf)
                component.GetComponent<Animator>().Play("DisappearShrink");

        }
    }



    public void OnBaseButtonClick(string name)
    {
        foreach(GameObject layer2Component in layer2Components)
        {
            if (layer2Component.name == name)
            {
                layer2Component.SetActive(true);
                BookScript.Instance.SetLayer2Active(true);
                break;
            }
        }
    }

    public void OnLayer2ButtonClick()
    {
        EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.SetActive(false);
        BookScript.Instance.SetLayer2Active(false);
    }

    IEnumerator WaitAndDo(float time, Action action)
    {
        yield return new WaitForSeconds(time);
        action();
    }
}
