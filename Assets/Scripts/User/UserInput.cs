using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public bool turnLeft = false;
    public bool turnRight = false;

	void Start ()
    {
		
	}

    public void ClearInput()
    {
        turnLeft = false;
        turnRight = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("left"))
        {
            turnLeft = true;
        }

        if (Input.GetKeyDown("right"))
        {
            turnRight = true;
        }
	}
}
