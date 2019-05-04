using UnityEngine;

public class PageScript : CanvasController
{
    public GameObject[] sparkles;

    new public void Start()
    {
        base.Start();
    }

    override protected void DisappearAnimations()
    {
        foreach (GameObject component in baseComponents)
        {
            if (component.activeSelf)
                if (component.GetComponent<Animator>() != null)
                    component.GetComponent<Animator>().Play("DisappearShrink");

        }
    }

    override public void OnBaseButtonClick()
    {
        base.OnBaseButtonClick();
        foreach (GameObject sparkle in sparkles)
            sparkle.SetActive(false);
    }

    override public void OnLayer2ButtonClick()
    {
        base.OnLayer2ButtonClick();
        foreach (GameObject sparkle in sparkles)
            sparkle.SetActive(true);
    }
}
