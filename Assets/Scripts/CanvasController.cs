using System.Collections;
using UnityEngine;

public abstract class CanvasController: MonoBehaviour
{
    protected readonly float TIME_DELAY_REVEAL_COMPONENTS = 0.2f;
    protected readonly float TIME_DELAY_HIDE_COMPONENTS = 0.2f;


    protected void Start()
    {
    }

    abstract public void OnPageFlip(int newCurrPage, string direction);

    abstract public void OnButtonClick();

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