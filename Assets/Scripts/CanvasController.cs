using System.Collections;
using UnityEngine;

public abstract class CanvasController: MonoBehaviour
{
    protected GameObject basecomponents;

    protected readonly float TIME_DELAY_REVEAL_COMPONENTS = 0.3f;

    protected void Start()
    {
        basecomponents = transform.Find("basecomponents").gameObject;
        HideComponents();
    }

    abstract public void OnPageFlip(int newCurrPage, string direction);

    abstract public void OnButtonClick();

    protected IEnumerator RevealComponents(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        MoveGameobjectToForeground();
        basecomponents.SetActive(true);
    }

    protected void HideComponents()
    {
        MoveGameobjectToBackground();
        basecomponents.SetActive(false);
    }

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

}