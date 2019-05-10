using UnityEngine;

public class Drift : MonoBehaviour
{
    private Vector3 originalPosition;
    private float SIN_AMPLITUDE = 0.05f;
    private float COS_AMPLITUDE = 0.05f;

    private float sinRate;
    private float cosRate;

    private float randomOffset;

    private void Start()
    {
        originalPosition = transform.position;
        randomOffset = Random.Range(0f, 10f);
        sinRate = cosRate = 1.5f + Random.Range(-0.5f, 0.5f);
    }

    void Update()
    {
        transform.position = new Vector3(originalPosition.x + SIN_AMPLITUDE * Mathf.Sin(randomOffset + Time.time * sinRate),
                                         originalPosition.y + COS_AMPLITUDE * Mathf.Cos(randomOffset + Time.time * cosRate),
                                         originalPosition.z);
    }
}
