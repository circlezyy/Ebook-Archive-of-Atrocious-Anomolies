using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Wendigo_4_5 : CanvasController
{
    private CanvasGroup canvasGroup;

    public GameObject MushroomNote;
    public GameObject HoofNote;
    public GameObject SkullNote;

    public GameObject Layer2_1_container;
    public GameObject Layer2_2_container;
    public GameObject Layer2_3_container;

    new public void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        StartCoroutine(DeactivateComponents(0.0f));

        FindObjectOfType<BookScript>().PageFlipEvent += OnPageFlip;
    }

    override public void OnPageFlip(int newCurrPage, string direction)
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

        MushroomNote.SetActive(true);
        HoofNote.SetActive(true);
        SkullNote.SetActive(true);

        MushroomNote.GetComponent<Animator>().Play("Appear");
        HoofNote.GetComponent<Animator>().Play("Appear");
        SkullNote.GetComponent<Animator>().Play("Appear");
    }

    protected void DisappearAnimations()
    {
        MushroomNote.GetComponent<Animator>().Play("Disappear");
        HoofNote.GetComponent<Animator>().Play("Disappear");
        SkullNote.GetComponent<Animator>().Play("Disappear");
    }

    protected IEnumerator DeactivateComponents(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        MushroomNote.SetActive(false);
        HoofNote.SetActive(false);
        SkullNote.SetActive(false);
    }

    override public void OnButtonClick()
    {
        switch(EventSystem.current.currentSelectedGameObject.name)
        {
            case "button_Mushroomnote_wendigo":
                Layer2_1_container.SetActive(true);
                break;
            case "button_Hoofnote_wendigo":
                Layer2_2_container.SetActive(true);
                break;
            case "button_Skullnote_wendigo":
                Layer2_3_container.SetActive(true);
                break;
            case "button_Layer2_1":
                Layer2_1_container.SetActive(false);
                break;
            case "button_Layer2_2":
                Layer2_2_container.SetActive(false);
                break;
            case "button_Layer2_3":
                Layer2_3_container.SetActive(false);
                break;
        }
    }
}
