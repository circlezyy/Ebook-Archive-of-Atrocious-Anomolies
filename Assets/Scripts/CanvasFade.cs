using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFade : MonoBehaviour
{

    void OnEnable()
    {
        InvokeRepeating("Spin", 0, 0.1f);
    }

    void OnDisable()
    {
        CancelInvoke();
    }

    void Spin()
    {
        print("spin");
    }
}
