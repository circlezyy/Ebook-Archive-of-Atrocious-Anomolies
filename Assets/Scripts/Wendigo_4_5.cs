using UnityEngine;
using UnityEngine.EventSystems;

public class Wendigo_4_5 : CanvasController
{
    private GameObject Layer2_1_container;
    private GameObject Layer2_2_container;
    private GameObject Layer2_3_container;

    new public void Start()
    {
        base.Start();
        Layer2_1_container = transform.Find("Layer2_1_container").gameObject;
        Layer2_2_container = transform.Find("Layer2_2_container").gameObject;
        Layer2_3_container = transform.Find("Layer2_3_container").gameObject;

        FindObjectOfType<BookScript>().PageFlipEvent += OnPageFlip;
    }

    override public void OnPageFlip(int newCurrPage, string direction)
    {
        if (newCurrPage == 2)
        {
            StartCoroutine(RevealComponents(TIME_DELAY_REVEAL_COMPONENTS));
        }
        else
        {
            StopAllCoroutines();
            HideComponents();
        }
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
