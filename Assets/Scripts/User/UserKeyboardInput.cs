using UnityEngine;

public class UserKeyboardInput : IUserInput
{
    private bool canFlip;

    public string GetInput()
    {
        if (canFlip && Input.GetKeyDown("left"))
        {
            canFlip = false;
            return "left";
        }
        else if (canFlip && Input.GetKeyDown("right"))
        {
            canFlip = false;
            return "right";
        }
        else
        {
            canFlip = true;
        }
        return null;
    }
}
