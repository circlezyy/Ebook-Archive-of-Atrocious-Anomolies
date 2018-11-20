using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glowPulse : MonoBehaviour
{
	void Update ()
    {
        Color tmp = transform.GetComponent<SpriteRenderer>().color;
        tmp.a = 0.2f + Mathf.PingPong(Time.time, 0.4f);
        transform.GetComponent<SpriteRenderer>().color = tmp;
    }
}
