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
        else if (Input.GetKey("="))
        {
            return "musicUp";
        }
        else if (Input.GetKey("-"))
        {
            return "musicDown";
        }
        else if (Input.GetKey("0"))
        {
            return "sfxUp";
        }
        else if (Input.GetKey("9"))
        {
            return "sfxDown";
        }

        return null;
    }
}
