using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Map_2_3 : MonoBehaviour
{
    protected readonly float TIME_DELAY_REVEAL_COMPONENTS = 0.2f;
    protected readonly float TIME_DELAY_HIDE_COMPONENTS = 0.2f;

    private CanvasGroup canvasGroup;
    private string SelectedIcon;

    public GameObject[] baseComponent;

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

        StartCoroutine(DeactivateComponents(0.0f));

        FindObjectOfType<BookScript>().PageFlipEvent += OnPageFlip;
    }

    public void OnPageFlip(int newCurrPage, string direction)
    {
        if (newCurrPage == 1)
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            StartCoroutine(ActivateComponents(TIME_DELAY_REVEAL_COMPONENTS));
            SelectedIcon = "";
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

        foreach (GameObject component in baseComponent)
        {
            component.SetActive(true);
            component.GetComponent<Animator>().Play("Appear");
        }
    }

    protected void DisappearAnimations()
    {
        foreach (GameObject component in baseComponent)
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

    protected IEnumerator DeactivateComponents(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        foreach (GameObject component in baseComponent)
            component.SetActive(false);
    }

    public void OnIconSelected()
    {
        SelectedIcon = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(SelectedIcon);
    }
}
