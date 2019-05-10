using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public void FlipLeftComplete()
    {
        BookScript.Instance.FlipLeftCompleted();
    }

    public void FlipRightComplete()
    {
        BookScript.Instance.FlipRightCompleted();
    }
}
