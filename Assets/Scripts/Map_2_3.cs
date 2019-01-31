using UnityEngine;
using UnityEngine.EventSystems;

public class Map_2_3 : CanvasController
{
    new public void Start()
    {
        base.Start();
        FindObjectOfType<BookScript>().PageFlipEvent += OnPageFlip;
    }

    override public void OnPageFlip(int newCurrPage, string direction)
    {
        if (newCurrPage == 1)
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
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
    }
}
