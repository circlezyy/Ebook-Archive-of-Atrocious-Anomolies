using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Map_2_3 : CanvasController
{
    private CanvasGroup canvasGroup;

    public GameObject nightcrawler;
    public GameObject leyak;
    public GameObject wendigo;
    public GameObject jorogumo;
    public GameObject lusca;
    public GameObject nguruvilu;

    new public void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        StartCoroutine(DeactivateComponents(0.0f));

        FindObjectOfType<BookScript>().PageFlipEvent += OnPageFlip;
    }

    override public void OnPageFlip(int newCurrPage, string direction)
    {
        if (newCurrPage == 1)
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

        nightcrawler.SetActive(true);
        leyak.SetActive(true);
        wendigo.SetActive(true);
        jorogumo.SetActive(true);
        lusca.SetActive(true);
        nguruvilu.SetActive(true);

        nightcrawler.GetComponent<Animator>().Play("Appear");
        leyak.GetComponent<Animator>().Play("Appear");
        wendigo.GetComponent<Animator>().Play("Appear");
        jorogumo.GetComponent<Animator>().Play("Appear");
        lusca.GetComponent<Animator>().Play("Appear");
        nguruvilu.GetComponent<Animator>().Play("Appear");
    }

    protected void DisappearAnimations()
    {
        nightcrawler.GetComponent<Animator>().Play("Disappear");
        leyak.GetComponent<Animator>().Play("Disappear");
        wendigo.GetComponent<Animator>().Play("Disappear");
        jorogumo.GetComponent<Animator>().Play("Disappear");
        lusca.GetComponent<Animator>().Play("Disappear");
        nguruvilu.GetComponent<Animator>().Play("Disappear");
    }

    protected IEnumerator DeactivateComponents(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        nightcrawler.SetActive(false);
        leyak.SetActive(false);
        wendigo.SetActive(false);
        jorogumo.SetActive(false);
        lusca.SetActive(false);
        nguruvilu.SetActive(false);
    }

    override public void OnButtonClick()
    {
        //Debug.Log(EventSystem.current.currentSelectedGameObject.name);
    }
}
