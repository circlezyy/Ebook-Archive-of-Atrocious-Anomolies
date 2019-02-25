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

        StartCoroutine(DeactivateComponents(0.0f));

        FindObjectOfType<BookScript>().PageFlipEvent += OnPageFlip;
    }

    public void OnPageFlip(int newCurrPage, string direction)
    {
        if (newCurrPage == 2)
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            StartCoroutine(ActivateComponents(TIME_DELAY_REVEAL_COMPONENTS));
        }
        else
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            DisappearAnimations();
            StartCoroutine(DeactivateComponents(TIME_DELAY_HIDE_COMPONENTS));
        }
    }

    IEnumerator ActivateComponents(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        foreach (GameObject component in baseComponents)
        {
            component.SetActive(true);
            component.GetComponent<Animator>().Play("Appear");
        }
    }

    protected void DisappearAnimations()
    {
        foreach (GameObject component in baseComponents)
        {
            if (component.activeSelf)
                component.GetComponent<Animator>().Play("Disappear");

        }
    }

    protected IEnumerator DeactivateComponents(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        foreach (GameObject component in baseComponents)
            component.SetActive(false);
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
}
