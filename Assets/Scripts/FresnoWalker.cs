using UnityEngine;

public class FresnoWalker : CanvasController
{
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
}
