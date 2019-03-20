using System.Collections;
using UnityEngine;

public class Layer2Move : MonoBehaviour
{
    public Transform startTransform;
    public Transform endTransform;
    public float speed = 10;
    private float maxDistance;

    private void OnEnable()
    {
        transform.position = startTransform.position;
        maxDistance = Vector3.Distance(startTransform.position, endTransform.position);
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while(Vector3.Distance(transform.position, endTransform.position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, endTransform.position, Time.deltaTime * speed);
            yield return null;
        }
        transform.position = endTransform.position;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
