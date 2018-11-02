using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillate : MonoBehaviour {

    public float amplitude;
    public float rate;

    //private Vector3 pos;

	// Use this for initialization
	void Start () {
        //pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(0, 0, amplitude * Mathf.Sin(Time.time * rate));
	}
}
