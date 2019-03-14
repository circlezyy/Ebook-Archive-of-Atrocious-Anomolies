using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotSpot : MonoBehaviour
{
    ParticleSystem ps;
    Vector3 startPosition;
    float radius = 0.8f;
    float rate = 5;

    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
        startPosition = transform.position;
        InvokeRepeating("Disable", 3, 3);
    }

    private void OnEnable()
    {}

    void Update()
    {
        transform.position = new Vector3(startPosition.x + radius * Mathf.Sin(Time.time * rate), startPosition.y + radius * Mathf.Cos(Time.time * rate), startPosition.z);
    }

    private void Disable()
    {
        ps.Play();
        //Debug.Log("Play");
        //gameObject.SetActive(false);
    }
}
