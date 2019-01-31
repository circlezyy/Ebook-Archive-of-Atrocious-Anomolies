using UnityEngine;

public class UserIPadInput : IUserInput
{
    //RaycastHit2D hit;
    //Vector2[] touches = new Vector2[5];

    public Vector2 startPos;
    public Vector2 direction;
    public bool directionChosen;

    public string GetInput()
    {
        // Track a single touch as a direction control.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Handle finger movements based on touch phase.
            switch (touch.phase)
            {
                // Record initial touch position.
                case TouchPhase.Began:
                    startPos = touch.position;
                    directionChosen = false;
                    break;

                // Determine direction by comparing the current touch position with the initial one.
                case TouchPhase.Moved:
                    direction = touch.position - startPos;
                    break;

                // Report that a direction has been chosen when the finger is lifted.
                case TouchPhase.Ended:
                    directionChosen = true;
                    break;
            }
        }

        if (directionChosen)
        {
            directionChosen = false;
            if (direction.x < 0)
                return "left";

            if (direction.x > 0)
                return "right";
        }

        return null;
    }
}
