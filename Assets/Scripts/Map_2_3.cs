using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Map_2_3 : MonoBehaviour
{
    protected readonly float TIME_DELAY_REVEAL_COMPONENTS = 0.2f;
    protected readonly float TIME_DELAY_HIDE_COMPONENTS = 0.2f;

    private CanvasGroup canvasGroup;
    private string SelectedIcon;

    public GameObject[] baseComponents;

    protected void MoveGameobjectToForeground()
    {
        transform.position = new Vector3(transform.position.x,
                                         transform.position.y,
                                         0);
    }

    protected void MoveGameobjectToBackground()
    {
        transform.position = new Vector3(transform.position.x,
                                         transform.position.y,
                                         -10);
    }

    public void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        StartCoroutine(WaitAndDo(TIME_DELAY_HIDE_COMPONENTS, DeactivateComponents));
        FindObjectOfType<BookScript>().PageFlipEvent += OnPageFlip;
    }

    public void OnPageFlip(int newCurrPage, string direction)
    {
        if (newCurrPage == 1)
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            StartCoroutine(WaitAndDo(TIME_DELAY_REVEAL_COMPONENTS, ActivateComponents));

            SelectedIcon = "";
        }
        else
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            DisappearAnimations();

            StartCoroutine(WaitAndDo(TIME_DELAY_HIDE_COMPONENTS, DeactivateComponents));
        }
    }

    protected void DisappearAnimations()
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
            }
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

    public void OnIconSelected()
    {
        if (SelectedIcon == "")
        {
            Debug.Log(EventSystem.current.currentSelectedGameObject.name);
            EventSystem.current.currentSelectedGameObject.GetComponent<Animator>().Play("GrowHoldShrink");
            SelectedIcon = EventSystem.current.currentSelectedGameObject.name;

            StartCoroutine(WaitAndDo(0.5f, BookScript.Instance.AutoFlip));
        }
    }

    IEnumerator WaitAndDo(float time, Action action)
    {
        yield return new WaitForSeconds(time);
        action();
    }
}
