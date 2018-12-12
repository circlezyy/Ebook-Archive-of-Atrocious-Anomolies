using UnityEngine;

public class UserKeyboardInput : IUserInput
{


    public string GetInput()
    {
        if (Input.GetKeyDown("left"))
        {
            return "left";
        }
        else if (Input.GetKeyDown("right"))
        {
            return "right";
        }

        return null;
    }
}
