using UnityEngine;
using UnityEngine.UI;

public class UserIPadInput : IUserInput
{
    private Text dirText;
    private Text dotText;
    private Text dirMagnitudeText; 
         
    public Vector2 startPos;
    public Vector2 direction;
    public bool directionChosen;

    public UserIPadInput(Text dir, Text dot, Text mag)
    {
        dirText = dir;
        dotText = dot;
        dirMagnitudeText = mag;
    }

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
                    dirText.text = "";
                    dotText.text = "";
                    dirMagnitudeText.text = "";

                    startPos = touch.position;
                    direction = Vector2.zero;
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
            dirText.text = direction.ToString();
            dotText.text = Vector2.Dot(direction.normalized, new Vector2(-1, 0)).ToString();
            dirMagnitudeText.text = direction.magnitude.ToString();

            directionChosen = false;

            if (direction.magnitude > 200)
            {
                if (Vector2.Dot(direction.normalized, new Vector2(-1, 0)) > 0.8f)
                    return "left";

                if (Vector2.Dot(direction.normalized, new Vector2(1, 0)) > 0.8f)
                    return "right";
            }
        }

        return null;
    }
}
